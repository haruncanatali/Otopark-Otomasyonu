using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Otopark.API.Model;
using Otopark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Otopark.API.Controllers
{
    [Route("Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<Kullanici> kullaniciManager;
        private SignInManager<Kullanici> kullaniciGirisManager;
        private ApplicationSettings _appSettings;

        public AccountController(UserManager<Kullanici> kullaniciManager, SignInManager<Kullanici> x,IOptions<ApplicationSettings> appSettings)
        {
            this.kullaniciManager = kullaniciManager;
            kullaniciGirisManager = x;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await kullaniciManager.FindByNameAsync(model.KullaniciAdi);
            if (user != null)
            {
                await kullaniciGirisManager.SignOutAsync();
                var result = await kullaniciGirisManager.PasswordSignInAsync(user, model.Sifre, false, false);
                if (result.Succeeded)
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("UserId", user.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return Ok(new { token });
                }
            }
            return BadRequest(new {message = "Incorrect Username or Password" });
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await kullaniciGirisManager.SignOutAsync();
            return Ok("Çıkış Başarılı Oldu.");
        }

    }
}
