using CashSoftware.DtoLayer.Dtos.ApplicationUserDtos;
using CashSoftware.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CashSoftware.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ApplicationUserRegisterDto applicationUserRegisterDto)
        {
            if (ModelState.IsValid) {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    UserName = applicationUserRegisterDto.UserName,
                    Email = applicationUserRegisterDto.Email,
                    NameSurname = applicationUserRegisterDto.NameSurname,
                };

                var result = await _userManager.CreateAsync(applicationUser, applicationUserRegisterDto.Password);
                if (result.Succeeded) { 
                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
