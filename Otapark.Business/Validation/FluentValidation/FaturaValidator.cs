using FluentValidation;
using Otopark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otapark.Business.Validation.FluentValidation
{
    public class FaturaValidator:AbstractValidator<Fatura>
    {
        public FaturaValidator()
        {
            RuleFor(c => c.ParkSuresi).Length(1, 20).WithMessage("ParkSuresi Max 20 karakterden oluşmalıdır.").NotNull().WithMessage("ParkSuresi alanı boş geçilemez.");
            RuleFor(c => c.Ucret).NotNull().WithMessage("Ucret alanı boş geçilemez.");
            RuleFor(c => c.Tarih).NotNull().WithMessage("Tarih alanı boş geçilemez.");
            RuleFor(c => c.AracId).NotNull().WithMessage("AracId alanı boş geçilemez.");
        }
    }
}
