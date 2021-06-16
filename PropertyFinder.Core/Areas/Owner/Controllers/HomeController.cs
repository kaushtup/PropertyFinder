using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PropertyFinder.Data.Models;
using PropertyFinder.Data.ViewModel;
using PropertyFinder.Helper;

namespace PropertyFinder.Core.Areas.Owner.Controllers
{
    [Authorize(Policy = "Owners")]
    [Area("Owner")]
    //[CustomAttribute("Human Resource", "Home Controller", "This is a admin home controller.")]
    public class HomeController : Controller
    {
        private readonly IDbHelper _helper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IDbHelper helper, IHttpContextAccessor httpContextAccessor)
        {
            _helper = helper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");
            var messageData = await _helper.GetMessageByOwnerIdAsync(Convert.ToInt32(userId));

            var count = messageData.Where(x => x.IsChecked == false && x.IsOwner == false).Count();

            ViewData["MessageCount"] = count;

            var userdata = _helper.GetUserByIdAsync(Convert.ToInt32(userId));

            ViewData["UserName"] = userdata.Result.Firstname;

            return View();
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
            model.AvailableDate = houseInfoData.AvailableDate.ToString("MM/dd/yyyy");
            model.IsRent = houseInfoData.IsRent;


            var housePhoto = await _helper.GetPhotoByHouseIdAsync(houseInfoData.Id);

            var photoList = new List<Photo>();
            foreach (var photoItem in housePhoto)
            {
                var photo =  _helper.GetPhotoByIdAsync(photoItem.PhotoId);
                photoList.Add(photo);
            }

            model.Photo = photoList;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditHouse(HouseDisplayViewModel model)
        {
            var addressInfo = await _helper.GetAddressInfosAsync();
            ViewData["AddressData"] = new SelectList(addressInfo, "Id", "Name");

            var houseTypes = await _helper.GetHouseTypesAsync();
            ViewData["HouseTypeData"] = new SelectList(houseTypes, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> Edit_HouseInfo(IFormFile files)
        {
            var image = Request.Form.Files;
            bool imagStat = true;

            if(image.Count == 0) 
            {
                if (Request.Form.Count > 9) 
                {
                    foreach (var item in Request.Form)
                    {
                        if(item.Key != "id" && item.Key != "title" && item.Key != "description" && item.Key != "cost"
                            && item.Key != "availabledate" && item.Key != "isrent" &&
                            item.Key != "housetypeid" && item.Key != "addressinfoid" && item.Key != "numberofbedroom") 
                        {
                            if(item.Value == "false") 
                            {
                                imagStat = false;
                            }
                        }
                    }
                }
                else 
                {
                    return Json("Select Image. Image is mandatory");
                }

                if (imagStat == true)
                {
                    return Json("Select Image. Image is mandatory");
                }
            }

            

            var id = "";
            var title = "";
            var description = "";
            var cost = "";
            var numberofbedroom = "";
            var availabledate = "";
            var isrent = "";
            var addressinfoid = "";
            var housetypeid = "";

            try 
            {
                foreach (var item in Request.Form)
                {
                    if (item.Key == "id")
                    {
                        id = item.Value;
                    }
                    else if (item.Key == "title")
                    {
                        title = item.Value;
                    }
                    else if (item.Key == "description")
                    {
                        description = item.Value;
                    }
                    else if (item.Key == "cost")
                    {
                        cost = item.Value;
                    }
                    else if (item.Key == "numberofbedroom")
                    {
                        numberofbedroom = item.Value;
                    }
                    else if (item.Key == "availabledate")
                    {
                        availabledate = item.Value;

                        int dateCompare = DateTime.Compare(Convert.ToDateTime(availabledate), DateTime.Now);
                        if (dateCompare < 0)
                        {
                            return Json("Available Date should be greater than current date.");
                        }
                    }
                    else if (item.Key == "isrent")
                    {
                        isrent = item.Value;
                    }
                    else if (item.Key == "addressinfoid")
                    {
                        addressinfoid = item.Value;
                    }
                    else if (item.Key == "housetypeid")
                    {
                        housetypeid = item.Value;
                    }
                    else
                    {
                        //old photos here
                        //remove from here and database code
                        if (item.Value == "true")
                        {
                            var photo = _helper.GetPhotoByNameAsync(item.Key);

                            var delHousePhoto = _helper.DeleteHousePhotoByPhotoId(photo.Id);
                            var delPhoto = _helper.DeletePhotoById(photo.Id);

                            string _imageToBeDeleted = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", item.Key);
                            if ((System.IO.File.Exists(_imageToBeDeleted)))
                            {
                                System.IO.File.Delete(_imageToBeDeleted);
                            }
                        }
                    }
                }

                HouseInfoViewModel model = new HouseInfoViewModel();

                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");

                model.Id = Convert.ToInt32(id);
                model.Title = title;
                model.Description = description;
                model.AddressInfoId = Convert.ToInt32(addressinfoid);
                model.Cost = Convert.ToInt32(cost);
                model.NumberOfBedroom = Convert.ToInt32(numberofbedroom);
                model.AvailableDate = Convert.ToDateTime(availabledate);
                model.userId = Convert.ToInt32(userId);

                bool rentStat = false;
                if (isrent == "true")
                {
                    rentStat = true;
                }

                model.IsRent = rentStat;
                model.HouseTypeId = Convert.ToInt32(housetypeid);
                model.PhotoInfo = new List<string>();

                //new here
                foreach (var item in image)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", item.Name);
                    var stream = new FileStream(path, FileMode.Create);

                    await image[0].CopyToAsync(stream);
                    model.PhotoInfo.Add(item.FileName);
                }

                //edit to database and add image to database
                await _helper.UpdateHouseInfo(model);
            }
            catch(Exception e) 
            {
                return Json("Failure:",e);
            }

            return Json("Successl Saved");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteHouse(int id)
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

            _helper.DeleteFavouritesByHouseInfoIdAsync(id);
            _helper.DeleteHouseInfoById(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<JsonResult> Get_HouseInfoData()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");
            var houseInfoDatas = await _helper.GetHouseInfoByUserIdAsync(Convert.ToInt32(userId));

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
        public async Task<IActionResult> AddNewHouse()
        {
            var addressInfo = await _helper.GetAddressInfosAsync();
            ViewData["AddressData"] = new SelectList(addressInfo, "Id", "Name");

            var houseTypes = await _helper.GetHouseTypesAsync();
            ViewData["HouseTypeData"] = new SelectList(houseTypes, "Id", "Name");

            var model = new HouseInfoViewModel();
            return View(model);
        }

        //use transaction while adding
        [HttpPost]
        public async Task<IActionResult> AddNewHouse(HouseInfoViewModel model, string rentStatus)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");

            if (!ModelState.IsValid)
            {
                var addressInfo = await _helper.GetAddressInfosAsync();
                ViewData["AddressData"] = new SelectList(addressInfo, "Id", "Name");

                var houseTypes = await _helper.GetHouseTypesAsync();
                ViewData["HouseTypeData"] = new SelectList(houseTypes, "Id", "Name");

                return View(model);
            }

            if (rentStatus.Equals("Buy"))
            {
                model.IsRent = false;
            }
            else
            {
                model.IsRent = true;
            }

            int dateCompare = DateTime.Compare(model.AvailableDate, DateTime.Now);
            if (dateCompare < 0)
            {
                ViewBag.Result = "Available Date should be greater than current date.";
                var addressInfo = await _helper.GetAddressInfosAsync();
                ViewData["AddressData"] = new SelectList(addressInfo, "Id", "Name");

                var houseTypes = await _helper.GetHouseTypesAsync();
                ViewData["HouseTypeData"] = new SelectList(houseTypes, "Id", "Name");

                var vmodel = new HouseInfoViewModel();
                return View(vmodel);
            }

            try
            {
                if (model.Photo != null)
                {
                    model.PhotoInfo = new List<string>();
                    var photoData = await _helper.GetPhotoInfo();

                    foreach (IFormFile photo in model.Photo)
                    {
                        var photoCount = photoData.Where(x => x.Image == photo.FileName);

                        if(photoCount.Count() > 0) 
                        {
                            ViewBag.Result = photo.FileName + " Already Exists. Select Another Photo.";

                            var addressInfo = await _helper.GetAddressInfosAsync();
                            ViewData["AddressData"] = new SelectList(addressInfo, "Id", "Name");

                            var houseTypes = await _helper.GetHouseTypesAsync();
                            ViewData["HouseTypeData"] = new SelectList(houseTypes, "Id", "Name");

                            var vmodel = new HouseInfoViewModel();
                            return View(vmodel);
                        }

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photo.FileName);
                        var stream = new FileStream(path, FileMode.Create);
                        await photo.CopyToAsync(stream);
                        model.PhotoInfo.Add(photo.FileName);
                    }

                    await _helper.CreateHouseInfoAsync
                    (
                             model.Title,
                             model.Description,
                             model.PhotoInfo,
                             model.HouseTypeId,
                             model.AddressInfoId,
                             model.Cost,
                             model.NumberOfBedroom,
                             model.AvailableDate,
                             model.IsRent,
                             Convert.ToInt32(userId)
                     );
                }
            }
            catch (Exception e) 
            {
                ViewBag.Result = "Error Message:"+ e;
                var addressInfo = await _helper.GetAddressInfosAsync();
                ViewData["AddressData"] = new SelectList(addressInfo, "Id", "Name");

                var houseTypes = await _helper.GetHouseTypesAsync();
                ViewData["HouseTypeData"] = new SelectList(houseTypes, "Id", "Name");

                var vmodel = new HouseInfoViewModel();
                return View(vmodel);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ViewMessages()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");
            var messageData = await _helper.GetMessageByOwnerIdAsync(Convert.ToInt32(userId));

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


            var editData = _helper.UpdateMessageByOwnerIdAsync(Convert.ToInt32(userId));

            return View(listMsgViewModel);
        }

        [HttpGet]
        public IActionResult SendMessage(int tenantid) 
        {
            ViewData["TenantId"] = tenantid;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message model)
        {
            var ownerId = _httpContextAccessor.HttpContext.User.FindFirstValue("Id");

            await _helper.AddMessageAsync
            (
                  model.TenantId,
                  Convert.ToInt32(ownerId),
                    model.Messages,
                    DateTime.Now,
                    false,
                    true
            );

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
            return RedirectToAction("Login", "Login", new { area = "" });
        }
    }
}
