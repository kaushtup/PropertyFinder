using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PropertyFinder.Core.Authentication;
using PropertyFinder.Data.ViewModel;
using PropertyFinder.Helper;

namespace PropertyFinder.Core.Controllers
{
    public class LoginController : Controller
    {
        private readonly IDbHelper _dbHelper;

        public LoginController(IDbHelper helper)
        {
            this._dbHelper = helper;
        }

        [Models.CustomAttribute("", "Login", "This is a login page.")]
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Result = "Enter all the required fields in current format.";
                return View(model);
            }

            var user = await _dbHelper.GetUserAsync(model.Email);

            EncryptDecrypt obj = new EncryptDecrypt();
            var key = "E546C8DF278CD5931069B522E695D4F2";
            var decryptedString = "";

            if(user != null) 
            {
                decryptedString = obj.DecryptString(user.Password, key);
            } 

            if (user == null || !decryptedString.Equals(model.Password))
            {
                ViewBag.Result = "Invalid email or password.";
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Email, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.Email, model.Email));
                identity.AddClaim(new Claim("Id", user.Id.ToString()));

                if (user.RoleId == 1)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Admins"));
                }
                else if (user.RoleId == 2)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Owners"));
                }
                else if (user.RoleId == 3)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Tenants"));
                }

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = false });

                if (user.RoleId == 1)
                {
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });

                }
                else if (user.RoleId == 2)
                {

                    //HttpContext.Session.Set("UserId", "1");
                    return RedirectToAction("Index", "Home", new { Area = "Owner" });

                }
                else if (user.RoleId == 3)
                {

                    //HttpContext.Session.Set("UserId", "1");
                    return RedirectToAction("Index", "Home", new { Area = "Tenant" });
                }
            }
            return RedirectToAction("Login");
        }

        //[CustomAttribute("", "Register", "This is a signup page.")]
        [HttpGet]
        public ActionResult RegisterTenant()
        {
             return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegisterTenant(UserViewModel viewmodel)
        {
            EncryptDecrypt obj = new EncryptDecrypt();
            viewmodel.RoleId = 3;
            
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            var user = await _dbHelper.GetUserAsync(viewmodel.Email);

            if (user == null)
            {
                var key = "E546C8DF278CD5931069B522E695D4F2";

                var encryptedString = obj.EncryptString(viewmodel.Password, key);

                await _dbHelper.CreateUserAsync(
                 viewmodel.Firstname,
                 viewmodel.Lastname,
                 viewmodel.Contact,
                 viewmodel.Email,
                 encryptedString,
                 viewmodel.RoleId
                 );

                ViewBag.Result = "Saved Succesfully.";
                return View();
            }
            else
            {
                ViewBag.Result = "User already exists.Select another email.";
                return View(viewmodel);
            }
        }

        [HttpGet]
        public ActionResult RegisterOwner()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegisterOwner(UserViewModel viewmodel)
        {
            EncryptDecrypt obj = new EncryptDecrypt();
            viewmodel.RoleId = 2;

            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            var user = await _dbHelper.GetUserAsync(viewmodel.Email);

            if (user == null)
            {
                var key = "E546C8DF278CD5931069B522E695D4F2";

                var encryptedString = obj.EncryptString(viewmodel.Password, key);

                await _dbHelper.CreateUserAsync(
                 viewmodel.Firstname,
                 viewmodel.Lastname,
                 viewmodel.Contact,
                 viewmodel.Email,
                 encryptedString,
                 viewmodel.RoleId
                 );

                ViewBag.Result = "Saved Succesfully.";
                return View();
            }
            else
            {
                ViewBag.Result = "User already exists.Select another email.";
                return View(viewmodel);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _dbHelper.Dispose();
            base.Dispose(disposing);
        }
    }
}
