using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands;

namespace UdemyCarBook.Application.Validators.ReviewValidators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Müşteri Adı Boş Geçilemez.");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("En Az 5 Karakter Giriniz.");
            RuleFor(x => x.RatingValue).NotEmpty().WithMessage("Puan Boş Geçilemez.");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum Değeri Boş Geçilemez.");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("En Az 50 Karakter Giriş Yapınız.");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("En Fazla 500 Karakter Giriş Yapınız.");
        }
    }
}
