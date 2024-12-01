using Microsoft.AspNetCore.Mvc;

namespace CashSoftware.PresentationLayer.Controllers
{
    public class MyProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
