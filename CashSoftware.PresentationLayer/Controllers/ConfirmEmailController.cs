using CashSoftware.EntityLayer.Concrete;
using CashSoftware.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CashSoftware.PresentationLayer.Controllers
{
    public class ConfirmEmailController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public ConfirmEmailController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var emailValue = TempData["Email"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmEmailViewModel confirmEmailViewModel)
        {
            var emailValue = TempData["Email"];
            var user = await _userManager.FindByEmailAsync(confirmEmailViewModel.Email.ToString());

            if (user.ConfirmCode == confirmEmailViewModel.ConfirmCode) {
                return RedirectToAction("Index", "MyProfile");
            }
            return View();
        }
    }
}
