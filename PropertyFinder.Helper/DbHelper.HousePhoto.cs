using PropertyFinder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyFinder.Helper
{
    public partial class DbHelper
    {
        public async Task<List<HousePhoto>> GetPhotoByHouseIdAsync(int houseid)
        {
            var list = new List<HousePhoto>();
            (await new Repository<HousePhoto>(_context).FindAsync(x => x.HouseInfoId == houseid)).ToList().ForEach(x => list.Add(x));
            return list;
        }

        public List<HousePhoto> GetHousePhotoByPhotoIdAsync(int photoid)
        {
            var list = new List<HousePhoto>();
            (new Repository<HousePhoto>(_context).Find(x => x.PhotoId == photoid)).ToList().ForEach(x => list.Add(x));
            return list;
        }

        public bool DeleteHousePhotoByHouseIdAsync(int id)
        {
            var data = GetPhotoByHouseIdAsync(id);

            if (id < 1)
            {
                return false;
            }
            try
            {
                foreach (var item in data.Result)
                {
                     new Repository<HousePhoto>(_context).RemoveById(item.Id);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteHousePhotoByPhotoId(int photoid)
        {
            var housephoto = GetHousePhotoByPhotoIdAsync(photoid);

            if (photoid < 1)
            {
                return false;
            }
            try
            {
                foreach (var item in housephoto)
                {
                    new Repository<HousePhoto>(_context).RemoveById(item.Id);
                }
                
               
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
