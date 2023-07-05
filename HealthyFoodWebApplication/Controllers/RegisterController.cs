using HealthyFoodWebApplication.Models;
using HealthyFoodWebApplication.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace HealthyFoodWebApplication.Controllers
{
    public class RegisterController : Controller
    {
        HealthyFoodDbContext db = new HealthyFoodDbContext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RegistrationView()         
        {
            return View("RegistrationView");

        }
       
        public IActionResult AddingFirstTime(registerVM NewAccount)
        {
            ModelState.Clear();
            if (HttpContext.Request.Method == "POST")
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

                    ClaimsIdentity claims = new ClaimsIdentity(
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    claims.AddClaim(new Claim(ClaimTypes.Name, NewAccount.Username));
                    claims.AddClaim(new Claim("Password", NewAccount.Password));
                    claims.AddClaim(new Claim(ClaimTypes.Role, NewAccount.Role));
                    ClaimsPrincipal principal = new ClaimsPrincipal(claims);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("GetHomeView", "Home");




                }
                else
                {
                    return View();

                }

            }
            return View();
        }
        
    }
}
