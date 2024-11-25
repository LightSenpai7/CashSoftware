using CashSoftware.DtoLayer.Dtos.ApplicationUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSoftware.BusinessLayer.ValidationRules.ApplicationUserValidationRules
{
    public class ApplicationUserRegisterValidation: AbstractValidator<ApplicationUserRegisterDto>
    {

        public ApplicationUserRegisterValidation() {

            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad Soyad alanı boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-mail adı alanı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre adı alanı boş geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş geçilemez");

            RuleFor(x => x.NameSurname).MaximumLength(40).WithMessage("Lütfen en fazla 40 karaktre girişi yapınız");
            RuleFor(x => x.ConfirmPassword).Equal(y=> y.Password).WithMessage("Şifreleriniz eşleşmiyor");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir e-mail adresi giriniz");



        }
    }
}
