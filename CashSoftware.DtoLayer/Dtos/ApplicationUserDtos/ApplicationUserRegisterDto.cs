using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSoftware.DtoLayer.Dtos.ApplicationUserDtos
{
    public class ApplicationUserRegisterDto
    {
        public string UserName { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Password { get;}
        public string ConfirmPassword { get;}

        //[Required(ErrorMessage = "Zorunlu Alan!")]
        //[Display(Name = "Ad Soyad")]
        //[MaxLength(40, ErrorMessage = "En fazla 40 karakter girebilirsiniz!")]
    }
}

