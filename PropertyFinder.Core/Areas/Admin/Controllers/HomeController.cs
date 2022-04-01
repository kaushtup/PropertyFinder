using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(IDbHelper helper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _helper = helper;
            _httpContextAccessor = httpContextAccessor;
            this.webHostEnvironment = webHostEnvironment;
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
                var houseData = await _helper.GetPhotoByHouseIdAsync(item.Id);
                _helper.DeleteHousePhotoByHouseIdAsync(item.Id);
                

                foreach (var houseItem in houseData)
                {
                  
                     _helper.DeletePhotoById(houseItem.PhotoId);
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

          
            
            var messageData = await _helper.GetMessageByOwnerIdAsync(Id);

            foreach (var item in messageData)
            {
                _helper.DeleteMessageById(item.Id);
            }

            var t =  _helper.DeleteUserById(Id);



            //var provider = new PhysicalFileProvider(webHostEnvironment.WebRootPath);
            //var contents = provider.GetDirectoryContents(Path.Combine("images"));


            //var photos = await _helper.GetPhotoInfo();
            //bool stat = true;
            //foreach (var item in contents)
            //{
            //    stat = false;
            //    foreach (var items in photos)
            //    {
            //        if (item.Name == items.Image)
            //        {
            //            stat = true;
            //        }
            //    }

            //    if (stat == false)
            //    {

            //        string _imageToBeDeleted = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", item.Name);
            //        if ((System.IO.File.Exists(_imageToBeDeleted)))
            //        {

            //            System.IO.File.Delete(_imageToBeDeleted);
            //        }
            //    }

            //}




            return Json(Id);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteHouse(int id , int userid)
        {
            var houseData = await _helper.GetPhotoByHouseIdAsync(id);
            _helper.DeleteHousePhotoByHouseIdAsync(id);
          

            foreach (var item in houseData)
            {
                _helper.DeletePhotoById(item.PhotoId);
                var photo = _helper.GetPhotoByIdAsync(item.PhotoId);

                string _imageToBeDeleted = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photo.Image);
                if ((System.IO.File.Exists(_imageToBeDeleted)))
                {
                    System.IO.File.Delete(_imageToBeDeleted);
                }

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

            var messageData = await _helper.GetMessageByTenantIdAsync(Id);


            foreach (var item in messageData)
            {
                _helper.DeleteMessageById(item.Id);
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
