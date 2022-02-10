using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(u => u.UserMail).NotEmpty().WithMessage("Mail adını boş geçemezsiniz");
            RuleFor(u => u.Subject).NotEmpty().WithMessage("Konu adını boş geçemezsiniz");
            RuleFor(u => u.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz");
            RuleFor(u => u.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(u => u.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(u => u.Subject).MaximumLength(50).WithMessage("Lütfen maksimum 50 karakter girişi yapın");
        }
    }
}
