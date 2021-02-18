using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Otopark.API.Model;
using Otopark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otopark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserManager<Kullanici> kullaniciManager;
        private IPasswordValidator<Kullanici> passwordValidator;
        private IUserValidator<Kullanici> userValidator;
        private IPasswordHasher<Kullanici> passwordHasher;

        public UsersController(UserManager<Kullanici> kullaniciManager, IPasswordValidator<Kullanici> x, IUserValidator<Kullanici> y, IPasswordHasher<Kullanici> z)
        {
            this.kullaniciManager = kullaniciManager;
            passwordValidator = x;
            userValidator = y;
            passwordHasher = z;
        }

        [HttpGet]
        [Authorize]
        [Route("usersList")]
        public IActionResult ListOfUsers()
        {
            return Ok(kullaniciManager.Users);
        }

        [HttpPost]
        [Route("addUser")]
        [Authorize]
        public async Task<IActionResult> AddUser([FromBody]RegisterModel model)
        {
            Kullanici kullanici = new Kullanici
            {
                UserName = model.KullaniciAdi,
                Email = model.EMail,
                PhoneNumber = model.TelefonNumarasi
            };

            var result1 = passwordValidator.ValidateAsync(kullaniciManager, kullanici, model.Sifre);
            if (result1.Result.Succeeded)
            {
                var result2 = await kullaniciManager.CreateAsync(kullanici, model.Sifre);
                if (result2.Succeeded)
                {
                    return RedirectToAction("ListOfUsers");
                }
                else
                {
                    foreach (var item in result2.Errors)
                    {
                        ModelState.AddModelError(item.Code.ToString(), item.Description.ToString());
                    }
                }
            }
            else
            {
                foreach (var item in result1.Result.Errors)
                {
                    ModelState.AddModelError(item.Code.ToString(), item.Description.ToString());
                }
            }
            return BadRequest("Güncelleme Başarısız Oldu!=>" + ModelState.Values.SelectMany(ms => ms.Errors).Select(x => x.ErrorMessage.ToString()));
        }

        [HttpPost]
        [Authorize]
        [Route("findUser")]
        public async Task<IActionResult> FindUser([FromBody]string id)
        {
            var user = await kullaniciManager.FindByIdAsync(id);
            if (user!=null)
            {
                return Ok("Kullanıcı mevcut!");
            }
            else
            {
                return BadRequest("Kullanıcı bulunamadı!");
            }
        }

        [HttpPost]
        [Authorize]
        [Route("updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody]UpdateUserModel model)
        {
            var user = await kullaniciManager.FindByIdAsync(model.Id);
            if (user!=null)
            {
                var result1 = await passwordValidator.ValidateAsync(kullaniciManager, user, model.Password);
                if (result1.Succeeded)
                {
                    user.PasswordHash = passwordHasher.HashPassword(user, model.Password);
                    var result2 = kullaniciManager.UpdateAsync(user);
                    if (result2.Result.Succeeded)
                    {
                        return RedirectToAction("ListOfUsers");
                    }
                    else
                    {
                        foreach (var item in result2.Result.Errors)
                        {
                            ModelState.AddModelError(item.Code, item.Description);
                        }
                    }
                }
                else
                {
                    foreach (var item in result1.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }
            return BadRequest("Güncelleme Başarısız Oldu!=>" + String.Join('-', ModelState.Values.SelectMany(ms => ms.Errors).Select(x => x.ErrorMessage)));
        }

        [HttpPost]
        [Authorize]
        [Route("deleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody]DeleteUserModel model)
        {
            var user = await kullaniciManager.FindByIdAsync(model.Id);
            if (user!=null)
            {
                var result = await kullaniciManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListOfUsers");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }
            return BadRequest("Silinecek kullanıcı bulunamadı!");

        }

    }
}
