using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(m => m.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz.");
            RuleFor(m => m.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz.");
            RuleFor(m => m.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz.");
            RuleFor(m => m.MessageContent).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girin.");
            RuleFor(m => m.ReceiverMail).EmailAddress();
            RuleFor(m => m.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girin.");
            RuleFor(m => m.Subject).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter girin.");
        }
    }
}
