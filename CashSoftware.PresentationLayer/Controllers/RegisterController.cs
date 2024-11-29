using CashSoftware.DtoLayer.Dtos.ApplicationUserDtos;
using CashSoftware.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

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

                Random random = new Random();
                int code;
                code = random.Next(100000, 1000000);

                ApplicationUser applicationUser = new ApplicationUser()
                {
                    UserName = applicationUserRegisterDto.UserName,
                    Email = applicationUserRegisterDto.Email,
                    NameSurname = applicationUserRegisterDto.NameSurname,
                    ConfirmCode = code
                };

                var result = await _userManager.CreateAsync(applicationUser, applicationUserRegisterDto.Password);
                if (result.Succeeded) { 

                    MimeMessage mimeMessage = new MimeMessage();

                    MailboxAddress mailboxAddressForm = new MailboxAddress("Cash Software Admin", "demoproject@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", applicationUser.Email);

                    mimeMessage.From.Add(mailboxAddressForm);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Your confirmation code to perform the registration process" + code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Cash Software Confirmation Code";

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com", 587, false);
                    smtpClient.Authenticate("demoproject@gmail.com", "password");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);


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
