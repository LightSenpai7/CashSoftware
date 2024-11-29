using Microsoft.AspNetCore.Identity;

namespace CashSoftware.PresentationLayer.Models
{
    public class CustomIdentityValidator: IdentityErrorDescriber
    {

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parola en az {length} karakter olmalıdır"
            };
        }
    }
}
