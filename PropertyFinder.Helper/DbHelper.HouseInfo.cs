using PropertyFinder.Data.Models;
using PropertyFinder.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyFinder.Helper
{
    public partial class DbHelper
    {
        public async Task<bool> CreateHouseInfoAsync(string title, string description, List<string> photo,
                                                  int housetypeid, int addressinfoid, int cost, int numberofbedroom, DateTime availabledate, bool isrent,int userid)

            {
                var objHouse = new HouseInfo
                {
                    Title = title,
                    Description = description,
                    HouseTypeId = housetypeid,
                    AddressInfoId = addressinfoid,
                    Cost = cost,
                    NumberOfBedroom = numberofbedroom,
                    AvailableDate = availabledate,
                    IsRent = isrent,
                    UserId = userid
                };

                try
                {
                    var houseData = await new Repository<HouseInfo>(_context).AddAsync(objHouse);

                    foreach (var item in photo)
                    {
                        var objPhoto = new Photo
                        {
                            Image = item
                        };

                        var photoData = await new Repository<Photo>(_context).AddAsync(objPhoto);

                        var objHousePhoto = new HousePhoto
                        {
                            HouseInfoId = houseData.Id,
                            PhotoId = photoData.Id
                        };

                        await new Repository<HousePhoto>(_context).AddAsync(objHousePhoto);
                    }

                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

        public async Task<bool> UpdateHouseInfo(HouseInfoViewModel viewmodel)
        {
            try
            {
                var model = new HouseInfo();

                model.Id = viewmodel.Id;
                model.Title = viewmodel.Title;
                model.Description = viewmodel.Description;
                model.HouseTypeId = viewmodel.HouseTypeId;
                model.AddressInfoId = viewmodel.AddressInfoId;
                model.Cost = viewmodel.Cost;
                model.NumberOfBedroom = viewmodel.NumberOfBedroom;
                model.AvailableDate = viewmodel.AvailableDate;
                model.IsRent = viewmodel.IsRent;
                model.UserId = viewmodel.userId;
               
                new Repository<HouseInfo>(_context).Update(model, model.Id);


                foreach (var item in viewmodel.PhotoInfo)
                {
                    var objPhoto = new Photo
                    {
                        Image = item
                    };

                    var photoData = await new Repository<Photo>(_context).AddAsync(objPhoto);

                    var objHousePhoto = new HousePhoto
                    {
                        HouseInfoId = viewmodel.Id,
                        PhotoId = photoData.Id
                    };

                    await new Repository<HousePhoto>(_context).AddAsync(objHousePhoto);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> AddUserFavourite(int houseinfoid, int userid)
        {
            var objFavourite = new Favourite
            {
                HouseInfoId = houseinfoid,
                UserId = userid
            };

            try
            {
                await new Repository<Favourite>(_context).AddAsync(objFavourite);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> RemoveUserFavourite(int houseinfoid, int userid)
        {
            var data = await new Repository<Favourite>(_context).FindAsync(x => x.HouseInfoId == houseinfoid && x.UserId == userid);

            try
            {
                await new Repository<Favourite>(_context).RemoveByIdAsync(data.FirstOrDefault().Id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<Favourite>> GetUserFavouriteByIdAsync(int userid)
        {
            var list = new List<Favourite>();
            (await new Repository<Favourite>(_context).FindAsync(x => x.UserId == userid)).ToList().ForEach(x => list.Add(x));
            return list;
        }

        public async Task<List<Favourite>> GetFavouriteByHouseIdAsync(int houseid)
        {
            var list = new List<Favourite>();
            (await new Repository<Favourite>(_context).FindAsync(x => x.HouseInfoId == houseid)).ToList().ForEach(x => list.Add(x));
            return list;
        }

        public async Task<List<Favourite>> GetFavouriteByUserIdAsync(int userid)
        {
            var list = new List<Favourite>();
            (await new Repository<Favourite>(_context).FindAsync(x => x.UserId == userid)).ToList().ForEach(x => list.Add(x));
            return list;
        }


        public bool DeleteFavouritesByHouseInfoIdAsync(int id)
        {
            var data = GetFavouriteByHouseIdAsync(id);

            if (id < 1)
            {
                return false;
            }
            try
            {
                foreach (var item in data.Result)
                {
                    new Repository<Favourite>(_context).RemoveById(item.Id);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<HouseInfo>> GetHouseInfoByUserIdAsync(int userid)
            {
                var list = new List<HouseInfo>();
                (await new Repository<HouseInfo>(_context).FindAsync(x => x.UserId == userid)).ToList().ForEach(x => list.Add(x));
                return list;
            }

        public async Task<HouseInfo> GetHouseByIdAsync(int id)
        {
            return (await new Repository<HouseInfo>(_context).FindByIdAsync(id));
        }

        public async Task<List<HouseInfo>> GetHouseInfo() 
        {
            var list = new List<HouseInfo>();
            (await new Repository<HouseInfo>(_context).FindAllAsync()).ToList().ForEach(x => list.Add(x));
            return list;
        }

        public bool DeleteHouseInfoById(int id)
        {
            if (id < 1)
            {
                return false;
            }
            try
            {
                new Repository<HouseInfo>(_context).RemoveById(id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteFavouritesById(int id)
        {
            if (id < 1)
            {
                return false;
            }
            try
            {
                new Repository<Favourite>(_context).RemoveById(id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}


