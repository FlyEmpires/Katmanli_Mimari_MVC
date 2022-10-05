using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Mail Adresi Boş Olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adı Boş Olamaz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı Boş Olamaz");
            RuleFor(x => x.ReceiverMail).Equal(x=>x.ReceiverMail).WithMessage("Lütfen Doğru Mail Adresi Girdiğinizden Emin Olun.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Giriş Yapınız");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 100 Karakterden Fazla Giriş Yapmayınız");

        }

         
       
    }
}
