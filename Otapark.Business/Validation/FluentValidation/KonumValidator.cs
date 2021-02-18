using FluentValidation;
using Otopark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otapark.Business.Validation.FluentValidation
{
    public class KonumValidator:AbstractValidator<Konum>
    {
        public KonumValidator()
        {

            RuleFor(c => c.Kat).NotNull().WithMessage("Kat bilgisi boş geçilemez.");
            RuleFor(c => c.Durum).NotNull().WithMessage("Durum bilgisi boş geçilemez.");
            RuleFor(c => c.Cephe).Length(1, 50).WithMessage("Cephe alanı max 50 karakterden oluşmalıdır.").NotNull().WithMessage("Cephe bilgisi boş geçilemez.");
            RuleFor(c => c.Yer).Length(1, 25).WithMessage("Yer alanı max 25 karakterden oluşmalıdır.").NotNull().WithMessage("Yer bilgisi boş geçilemez.");
        }
    }
}
