using Microsoft.AspNetCore.Identity;
using Otopark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otopark.API.Helper
{
    public class CustomUserValidator : IUserValidator<Kullanici>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<Kullanici> manager, Kullanici user)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (user.UserName.Length < 6)
            {
                errors.Add(new IdentityError
                {
                    Code = "403",
                    Description = "Kullanıcı adı 6 karakterden az olamaz."
                });
            }

            return Task.FromResult(errors.Count() == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
