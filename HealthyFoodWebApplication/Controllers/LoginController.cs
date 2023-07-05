using HealthyFoodWebApplication.Models;
using HealthyFoodWebApplication.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace HealthyFoodWebApplication.Controllers
{
    public class LoginController : Controller
    {
        HealthyFoodDbContext db = new HealthyFoodDbContext();

      
        public IActionResult loginUser()
        {

            return View();
        }

        [HttpPost]

        public IActionResult loginUser(loginVm LogAccount)
        {
            Logger logger = new Logger();

            if (ModelState.IsValid)
            {

                var UserInput = db.Logger.Where(b => b.Username == LogAccount.Username && b.Password == LogAccount.Password).FirstOrDefault();
               
                if (UserInput != null)
                //if(User.IsInRole("Admin"))
                {
                    ClaimsIdentity claims = new ClaimsIdentity(
                    CookieAuthenticationDefaults.AuthenticationScheme);
                    claims.AddClaim(new Claim(ClaimTypes.Name, UserInput.Username));
                    claims.AddClaim(new Claim("Password", UserInput.Password));
                    claims.AddClaim(new Claim(ClaimTypes.Role, UserInput.Role));
                    ClaimsPrincipal principal = new ClaimsPrincipal(claims);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("GetHomeView", "Home");


                }
                else
                {
                    ModelState.AddModelError("", "Username or Password Doesn't Exist");
                }
            }

            return View("Error");
            
        }
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("loginUser");
        }
    }
}
