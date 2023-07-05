using HealthyFoodWebApplication.Models;
using HealthyFoodWebApplication.Repositories.CustomerMessageRepository;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWebApplication.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly ICustomerMessageRepository MessageRepository;
        public ContactUsController(ICustomerMessageRepository MsgRepo)
        {
            MessageRepository = MsgRepo;
        }

        public IActionResult GetMessageView()
        {
            if (ModelState.IsValid)
            {
                List<CustomerMessage> messages = MessageRepository.GetAll();
                return View("Message", messages);
            }
            return View("Message");
        }


        public IActionResult GetContactUsView()
        {
            return View("ContactUs");
        }
        [HttpPost]

        public IActionResult GetContactUsView(CustomerMessage Mesg)
        {
            if (ModelState.IsValid == true)
            {
                MessageRepository.Insert(Mesg);
                return RedirectToAction("GetContactUsView");
            }
            return View("ContactUs", Mesg);
        }

    }
}
