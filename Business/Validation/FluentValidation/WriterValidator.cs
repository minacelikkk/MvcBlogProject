using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w=>w.WriterFirstName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz.");
            RuleFor(w => w.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz.");
            RuleFor(w => w.WriterTitle).NotEmpty().WithMessage("Unvan kısmını boş geçemezsiniz.");
            RuleFor(w => w.WriterFirstName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız.");
            RuleFor(w => w.WriterFirstName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız.");
            RuleFor(w => w.WriterMail).NotEmpty().WithMessage("Maili boş geçemezsiniz.");
            RuleFor(w => w.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz.");
            RuleFor(w => w.WriterAbout.ToUpper()).Must(IncludeA).WithMessage("Hakkımda kısmı A harfi içermelidir.");   
        }
        private bool IncludeA(string writerAbout)
        {
            return writerAbout.Contains("A");
        }
    }
}
