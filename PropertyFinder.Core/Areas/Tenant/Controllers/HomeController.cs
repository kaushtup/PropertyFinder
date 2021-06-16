using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyFinder.Data.Models;
using PropertyFinder.Data.ViewModel;
using PropertyFinder.Helper;

namespace PropertyFinder.Core.Areas.Tenant.Controllers
{
    [Authorize(Policy = "Tenants")]
    [Area("Tenant")]
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

        public async Task<IActionResult> Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");
            var messageData = await _helper.GetMessageByTenantIdAsync(Convert.ToInt32(userId));

            var count = messageData.Where(x => x.IsChecked == false && x.IsOwner == true).Count();

            ViewData["MessageCount"] = count;

            var userData = _helper.GetUserByIdAsync(Convert.ToInt32(userId));

            ViewData["UserName"] = userData.Result.Firstname;

            return View();
        }

        [HttpGet]
        public async Task<JsonResult> Get_HouseInfoData()
        {
            //var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");
            //var houseInfoDatas = await _helper.GetHouseInfoByUserIdAsync(Convert.ToInt32(userId));

            var houseInfoDatas = await _helper.GetHouseInfo();
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

                var housePhoto = await _helper.GetPhotoByHouseIdAsync(house.Id);

                var photoList = new List<Photo>();
                foreach (var photoItem in housePhoto)
                {
                    var photo =  _helper.GetPhotoByIdAsync(photoItem.PhotoId);
                    photoList.Add(photo);
                }

                model.Photo = photoList;
                houseInfoList.Add(model);
            }

            return Json(houseInfoList);
        }

        [HttpGet]
        public async Task<JsonResult> Get_AddressInfo() 
        {
            var addressInfoData = await _helper.GetAddressInfosAsync();
            return Json(addressInfoData);
        }

        public IActionResult Favourites()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetFavourites() 
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");
            var data = await _helper.GetUserFavouriteByIdAsync(Convert.ToInt32(userId));

            var list = new List<HouseInfo>();
            foreach (var item in data)
            {
                var houseData = await _helper.GetHouseByIdAsync(item.HouseInfoId);
                list.Add(houseData);
            }

            var houseInfoList = new List<HouseDisplayViewModel>();
            foreach (var house in list)
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
                model.AvailableDate = house.AvailableDate.ToString("MM/dd/yyyy"); ;
                model.IsRent = house.IsRent;

                var housePhoto = await _helper.GetPhotoByHouseIdAsync(house.Id);

                var photoList = new List<Photo>();
                foreach (var photoItem in housePhoto)
                {
                    var photo =  _helper.GetPhotoByIdAsync(photoItem.PhotoId);
                    photoList.Add(photo);
                }

                model.Photo = photoList;
                houseInfoList.Add(model);
            }

            return Json(houseInfoList);
        }

        [HttpGet]
         
        public async Task<JsonResult> Get_UserFavourites() 
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");

            var data = await _helper.GetUserFavouriteByIdAsync(Convert.ToInt32(userId));

            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> Save_Favourite(HouseDisplayViewModel data) 
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");

            await _helper.AddUserFavourite
            (
                    Convert.ToInt32(data.Id),
                    Convert.ToInt32(userId)
            );

            return Json("Success");
        }


        [HttpPost]
        public async Task<JsonResult> Remove_Favourite(HouseDisplayViewModel data)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");

            await _helper.RemoveUserFavourite
            (
                   Convert.ToInt32(data.Id),
                   Convert.ToInt32(userId)
            );

            return Json("Success");
        }


        [HttpGet]
        public async Task<IActionResult> ViewHouse([FromRoute] int id)
        {
            var houseInfoData = await _helper.GetHouseByIdAsync(id);

            var addressInfo = await _helper.GetAddressByIdAsync(houseInfoData.AddressInfoId);
            var houseType = await _helper.GetHouseTypeByIdAsync(houseInfoData.HouseTypeId);

            var model = new HouseDisplayViewModel();
            model.Id = houseInfoData.Id;
            model.Title = houseInfoData.Title;
            model.Description = houseInfoData.Description;

            model.AddressInfoId = houseInfoData.AddressInfoId;
            model.AddressInfoName = addressInfo.Name;

            model.HouseTypeId = houseInfoData.HouseTypeId;
            model.HouseTypeName = houseType.Name;

            model.NumberOfBedroom = houseInfoData.NumberOfBedroom;
            model.Cost = houseInfoData.Cost;
            model.AvailableDate = houseInfoData.AvailableDate.ToString("MM/dd/yyyy"); ;
            model.IsRent = houseInfoData.IsRent;


            var housePhoto = await _helper.GetPhotoByHouseIdAsync(houseInfoData.Id);

            var photoList = new List<Photo>();
            foreach (var photoItem in housePhoto)
            {
                var photo = _helper.GetPhotoByIdAsync(photoItem.PhotoId);
                photoList.Add(photo);
            }

            model.Photo = photoList;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RequestMessage(int id)
        {
            var data = await _helper.GetHouseByIdAsync(id);

            ViewData["OwnerId"] = data.UserId;
            ViewData["HouseId"] = id;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RequestMessage(Message model)
        {
            var houseId = model.TenantId; // house id store in tenant id
            //save code

            var tenantId = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");

            await _helper.AddMessageAsync
            (
                    Convert.ToInt32(tenantId),
                    model.OwnerId,
                    model.Messages,
                    DateTime.Now,
                    false,
                    false

            );

            return RedirectToAction("ViewHouse", new { id = houseId });
        }


        [HttpGet]
        public async Task<IActionResult> ViewMessages()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");
            var messageData = await _helper.GetMessageByTenantIdAsync(Convert.ToInt32(userId));

            List<Message> listMsg = messageData.OrderByDescending(x => x.date).ToList();
            List<MessageViewModel> listMsgViewModel = new List<MessageViewModel>();

            foreach (var item in listMsg)
            {
                MessageViewModel vm = new MessageViewModel();

                var tenantData = _helper.GetUserByIdAsync(item.TenantId);

                vm.TenantId = item.TenantId;
                vm.TenantName = tenantData.Result.Firstname;
                vm.TenantEmail = tenantData.Result.Email;

                var ownerData = _helper.GetUserByIdAsync(item.OwnerId);

                vm.OwnerId = item.OwnerId;
                vm.OwnerName = ownerData.Result.Firstname;
                vm.OwnerEmail = ownerData.Result.Email;

                vm.Date = item.date;
                vm.Message = item.Messages;

                vm.IsOwner = item.IsOwner;

                listMsgViewModel.Add(vm);
            }

            var editData = _helper.UpdateMessageByTenantIdAsync(Convert.ToInt32(userId));

            return View(listMsgViewModel);
        }

        [HttpGet]
        public IActionResult SendMessage(int ownerid)
        {
            ViewData["OwnerId"] = ownerid;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message model)
        {
            var tenantId = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");

            await _helper.AddMessageAsync
            (
                  Convert.ToInt32(tenantId),
                  model.OwnerId,
                  model.Messages,
                  DateTime.Now,
                  false,
                  false
            );

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout() 
        {
            await HttpContext.SignOutAsync();
            HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
            return RedirectToAction("Login", "Login", new { area =  "" });
        }
    }
}
