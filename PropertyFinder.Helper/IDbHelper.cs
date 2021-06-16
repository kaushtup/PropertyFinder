using PropertyFinder.Data;
using PropertyFinder.Data.Models;
using PropertyFinder.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyFinder.Helper
{
    public interface IDbHelper:IDisposable
    {
        //User
        #region user
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserAsync(string email);
        bool DeleteUserById(int id);
        Task<bool> CreateUserAsync(string firstname,string lastname,string contact,string email, string password,int roleid);
        #endregion

        //Role
        #region role
        Task<List<Role>> GetRolesAsync();
        #endregion

        //Address
        #region address 
        Task<List<AddressInfo>> GetAddressInfosAsync();

        Task<AddressInfo> GetAddressByIdAsync(int id);
        #endregion region

        //House Type
        #region house type
        Task<List<HouseType>> GetHouseTypesAsync();

        Task<HouseType> GetHouseTypeByIdAsync(int id);
        #endregion regio

        //House Info
        #region houseinfo
        Task<bool> CreateHouseInfoAsync(string title, string description, List<string> photo, int housetypeid, 
                                       int addressinfoid, int cost, int numberofbedroom, DateTime availabledate,bool isrent,int userId);


        Task<List<HouseInfo>> GetHouseInfoByUserIdAsync(int userid);

        Task<List<HouseInfo>> GetHouseInfo();

        Task<HouseInfo> GetHouseByIdAsync(int id);

        Task<bool> AddUserFavourite(int houseinfoid, int userid);

        Task<bool> RemoveUserFavourite(int houseinfoid, int userid);

        Task<List<Favourite>> GetUserFavouriteByIdAsync(int userid);

        Task<List<Favourite>> GetFavouriteByHouseIdAsync(int houseid);

        Task<List<Favourite>> GetFavouriteByUserIdAsync(int userid);

        Task<bool> UpdateHouseInfo(HouseInfoViewModel viewmodel);

        bool DeleteFavouritesByHouseInfoIdAsync(int id);

        bool DeleteFavouritesById(int id);

        bool DeleteHouseInfoById(int id);

         #endregion

        //HousePhoto
        #region housephoto
        Task<List<HousePhoto>> GetPhotoByHouseIdAsync(int houseid);

        List<HousePhoto> GetHousePhotoByPhotoIdAsync(int photoid);

        bool DeleteHousePhotoByPhotoId(int photoid);

        bool DeletePhotoById(int photoid);

        #endregion

        //Photo
        #region photo
        Photo GetPhotoByIdAsync(int id);

        bool DeleteHousePhotoByHouseIdAsync(int id);

        Photo GetPhotoByNameAsync(string name);

        Task<List<Photo>> GetPhotoInfo();
        #endregion

        //message
        #region message
        Task<bool> AddMessageAsync(int tenantId, int ownerId, string message, DateTime currentdate, bool isChecked, bool isOwner);

        Task<List<Message>> GetMessageByOwnerIdAsync(int ownerid);

        bool UpdateMessageByOwnerIdAsync(int id);

        Task<List<Message>> GetMessageByTenantIdAsync(int tenantid);

        bool UpdateMessageByTenantIdAsync(int id);
        #endregion
    }
}
