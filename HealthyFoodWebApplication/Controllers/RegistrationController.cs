using HealthyFoodWebApplication.Models;
using HealthyFoodWebApplication.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthyFoodWebApplication.Controllers
{
    public class RegistrationController : Controller
    {
        HealthyFoodDbContext db = new HealthyFoodDbContext();


        // Redistrations Actions 
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RegistrationView()
        {
            ModelState.Clear();
            return View("RegistrationView");

        }
        [HttpPost]
        public IActionResult AddingFirstTime(registerVM NewAccount)
        {
            if (ModelState.IsValid)
            {
                Logger logger = new Logger();

                logger.FullName = NewAccount.FullName;
                logger.PhoneNumber = NewAccount.PhoneNumber;
                logger.Email = NewAccount.Email;
                logger.Username = NewAccount.Username;
                logger.Role = NewAccount.Role;
                logger.Password = NewAccount.Password;
                logger.ConfirmPassword = NewAccount.ConfirmPassword;
                db.Logger.Add(logger);
                db.SaveChanges();

                // create Principle 

                //ClaimsIdentity claims = new ClaimsIdentity( 
                //    CookieAuthenticationDefaults.AuthenticationScheme);
                //claims.AddClaim(new Claim("UserName", NewAccount.Username));
                //claims.AddClaim(new Claim("Password", NewAccount.Password));
                //claims.AddClaim(new Claim("Role", NewAccount.Role));


                //ClaimsPrincipal principal = new ClaimsPrincipal(claims);

                //HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                //return Redirect("RegistrationView");
                //return View("_DefaultLayout");

                return RedirectToAction("GetHomeView", "Home");
            }
            else
            {
                return View("test");
            }

        }

        /////////// Login Actions /////////////
        ///



        public IActionResult loginUser()
        {

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult loginUser(loginVm LogAccount)
        {

            if (ModelState.IsValid)
            {
                Logger logger = new Logger();

                var UserInput = db.Logger.Where(b => b.Username == LogAccount.Username && b.Password == LogAccount.Password).FirstOrDefault();
                if (UserInput != null)
                //if(User.IsInRole("Admin"))
                {
                    return View("Welcome");

                }
                else
                {
                    ModelState.AddModelError("", "Username or Password Doesn't Exist");
                }
            }

            return View("test");
        }

    }
}

