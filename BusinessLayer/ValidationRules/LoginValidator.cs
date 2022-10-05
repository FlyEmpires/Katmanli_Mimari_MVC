using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class LoginValidator : AbstractValidator<Admin>
    {
        public LoginValidator()
        {
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Admin Kullanıcı Adı Boş Olamaz");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Parola Boş Geçilemez");
            //RuleFor(x => x.AdminPassword).NotEqual(admin.AdminPassword).WithMessage("Parola Yanlış");



        }
      




    }
}
