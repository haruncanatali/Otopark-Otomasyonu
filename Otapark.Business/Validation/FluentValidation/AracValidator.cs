using FluentValidation;
using Otopark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otapark.Business.Validation.FluentValidation
{
    public class AracValidator:AbstractValidator<Arac>
    {
        public AracValidator()
        {
            RuleFor(c => c.TcKimlikNo).Length(11,11).WithMessage("Tc Kimlik No Max/Min 11 Hane Olmalıdır.").NotNull().WithMessage("Tc Kimlik No Alanı Boş Geçilemez.");
            RuleFor(c => c.Ad).Length(1,50).WithMessage("Ad Max 50 Hane Olmalıdır.").NotNull().WithMessage("Ad Alanı Boş Geçilemez.");
            RuleFor(c => c.Soyad).Length(1, 50).WithMessage("Soyad Max 50 Hane Olmalıdır.").NotNull().WithMessage("Soyad Alanı Boş Geçilemez.");
            RuleFor(c => c.TelefonNo).Length(1, 20).WithMessage("TelefonNo Max 20 Hane Olmalıdır.").NotNull().WithMessage("TelefonNo Alanı Boş Geçilemez.");
            RuleFor(c => c.Plaka).Length(1, 10).WithMessage("Plaka Max 10 Hane Olmalıdır.").NotNull().WithMessage("Plaka Alanı Boş Geçilemez.");
            RuleFor(c => c.Marka).Length(1, 50).WithMessage("Marka Max 50 Hane Olmalıdır.").NotNull().WithMessage("Marka Alanı Boş Geçilemez.");
            RuleFor(c => c.Model).Length(1, 50).WithMessage("Model Max 50 Hane Olmalıdır.").NotNull().WithMessage("Model Alanı Boş Geçilemez.");
            RuleFor(c => c.Renk).Length(1, 50).WithMessage("Renk Max 50 Hane Olmalıdır.").NotNull().WithMessage("Renk Alanı Boş Geçilemez.");
            RuleFor(c => c.KonumId).NotNull().WithMessage("KonumId Alanı Boş Geçilemez.");
        }
    }
}
