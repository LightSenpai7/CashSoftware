using CashSoftware.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CashSoftware.PresentationLayer.Controllers
{
    public class ConfirmEmailController : Controller
    {

        [HttpGet]
        public IActionResult Index(int id)
        {
            var emailValue = TempData["Email"];
            return View();
        }

        [HttpPost]
        public IActionResult Index(ConfirmEmailViewModel confirmEmailViewModel)
        {
            return View();
        }
    }
}
