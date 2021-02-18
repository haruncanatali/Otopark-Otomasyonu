using Microsoft.AspNetCore.Identity;
using Otopark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otopark.API.Helper
{
    public class CustomPasswordValidator : IPasswordValidator<Kullanici>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<Kullanici> manager, Kullanici user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();
            if(user.UserName.ToLower() == password.ToLower())
            {
                errors.Add(new IdentityError
                {
                    Code = "401",
                    Description = "Kullanıcı adı ile kullanıcı sifresi aynı olamaz!"
                });
            }
            if (password.Length < 6)
            {
                errors.Add(new IdentityError
                {
                    Code = "402",
                    Description = "Kullanıcı şifresi en az 6 karakterden oluşmak zorunda!"
                });
            }

            return Task.FromResult(errors.Count() == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
