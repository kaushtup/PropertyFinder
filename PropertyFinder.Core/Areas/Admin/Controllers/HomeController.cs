using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyFinder.Data.ViewModel;
using PropertyFinder.Helper;

namespace PropertyFinder.Core.Areas.Admin.Controllers
{
    [Authorize(Policy = "Admins")]
    [Area("Admin")]
    // [CustomAttribute("Human Resource", "Home Controller", "This is a admin home controller.")]
    public class HomeController : Controller
    {
        private readonly IDbHelper _helper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IDbHelper helper, IHttpContextAccessor httpContextAccessor)
        {
            _helper = helper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> Get_OwnerInfoData()
        {
            var userData = await _helper.GetUsersAsync();

            var finalData = userData.Where(x => x.RoleId == 2);

            return Json(finalData);
        }

        [HttpGet]
        public async Task<JsonResult> Get_TenantInfoData()
        {
            var userData = await _helper.GetUsersAsync();
            var finalData = userData.Where(x => x.RoleId == 3);
            return Json(finalData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Get_Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
            return RedirectToAction("Login", "Login", new { area = "" });
        }

        [HttpPost]
        public async Task<JsonResult> Delete_OwnerData(int Id)
        {
            var data = await _helper.GetHouseInfoByUserIdAsync(Id);

            foreach (var item in data)
            {
                var deletePhoto =  _helper.DeleteHousePhotoByHouseIdAsync(item.Id);
                var houseData = await _helper.GetPhotoByHouseIdAsync(item.Id);

                foreach (var houseItem in houseData)
                {
                    var del = _helper.DeletePhotoById(houseItem.PhotoId);

                    var photo = _helper.GetPhotoByIdAsync(houseItem.PhotoId);

                    string _imageToBeDeleted = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photo.Image);
                    if ((System.IO.File.Exists(_imageToBeDeleted)))
                    {
                        System.IO.File.Delete(_imageToBeDeleted);
                    }
                }

                var deleteFavourite = _helper.DeleteFavouritesByHouseInfoIdAsync(item.Id);
                var deleteHouseInfo = _helper.DeleteHouseInfoById(item.Id);
            }

            var t =  _helper.DeleteUserById(Id);

            return Json(Id);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteHouse(int id , int userid)
        {
            _helper.DeleteHousePhotoByHouseIdAsync(id);

            var houseData = await _helper.GetPhotoByHouseIdAsync(id);

            foreach (var item in houseData)
            {
                var photo = _helper.GetPhotoByIdAsync(item.PhotoId);

                string _imageToBeDeleted = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photo.Image);
                if ((System.IO.File.Exists(_imageToBeDeleted)))
                {
                    System.IO.File.Delete(_imageToBeDeleted);
                }

                _helper.DeletePhotoById(item.PhotoId);
            }

            var deleteFavourite = _helper.DeleteFavouritesByHouseInfoIdAsync(id);
            var deleteHouseInfo = _helper.DeleteHouseInfoById(id);

            return RedirectToAction("View_UserHouse", new { id = userid  });
        }

        [HttpPost]
        public async Task<JsonResult> Delete_TenantData(int Id) 
        {
           var data = await _helper.GetFavouriteByUserIdAsync(Id);

            foreach (var item in data)
            {
                _helper.DeleteFavouritesById(item.Id);
            }

            var t = _helper.DeleteUserById(Id);

            return Json(Id);
        }

        [HttpGet]
        public async Task<IActionResult> View_UserHouse(int id) 
        {
            ViewData["UserId"] = id;

            var houseInfoDatas = await _helper.GetHouseInfoByUserIdAsync(id);
            var houseInfoList = new List<HouseDisplayViewModel>();

            foreach (var house in houseInfoDatas)
            {
                var addressInfo = await _helper.GetAddressByIdAsync(house.AddressInfoId);
                var houseType = await _helper.GetHouseTypeByIdAsync(house.HouseTypeId);

                var model = new HouseDisplayViewModel();
                model.Id = house.Id;
                model.Title = house.Title;
                model.Description = house.Description;

                model.AddressInfoId = house.AddressInfoId;
                model.AddressInfoName = addressInfo.Name;

                model.HouseTypeId = house.HouseTypeId;
                model.HouseTypeName = houseType.Name;

                model.NumberOfBedroom = house.NumberOfBedroom;
                model.Cost = house.Cost;

                model.AvailableDate = house.AvailableDate.ToString("MM/dd/yyyy");
                model.IsRent = house.IsRent;

                houseInfoList.Add(model);
            }

            return View(houseInfoList);
        }
    }
}
