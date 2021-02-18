using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Otapark.Business.Abstract;
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
    public class AracController : ControllerBase
    {

        IAracService aracServis;
        IFaturaService faturaServis;

        public AracController(IAracService x,IFaturaService y)
        {
            aracServis = x;
            faturaServis = y;
        }

        [HttpPost]
        [Route("aracEkle")]
        public IActionResult AracEkle([FromBody]AracEkleModel model)
        {
            try
            {
                aracServis.Add(new Arac
                {
                    TcKimlikNo = model.TcKimlikNo,
                    Ad = model.Ad,
                    Soyad = model.Soyad,
                    TelefonNo = model.TelefonNo,
                    Plaka = model.Plaka,
                    Marka = model.Marka,
                    Model = model.Model,
                    Renk = model.Renk,
                    KonumId = int.Parse(model.KonumId)
                });


                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        [HttpGet]
        [Route("araclariGetir")]
        public IActionResult AraclariGetir()
        {
            return Ok(aracServis.List(null));
        }

        [HttpGet]
        [Route("aracGetir")]
        public IActionResult AracGetir(int id)
        {
            return Ok(aracServis.Get(c => c.Id == id));
        }

        [HttpPost]
        [Route("aracGuncelle")]
        public IActionResult AracGuncelle(AracEkleModel model)
        {
            try
            {
                aracServis.Update(new Arac
                {
                    Id = model.Id,
                    TcKimlikNo = model.TcKimlikNo,
                    Ad = model.Ad,
                    Soyad = model.Soyad,
                    TelefonNo = model.TelefonNo,
                    Plaka = model.Plaka,
                    Marka = model.Marka,
                    Model = model.Model,
                    Renk = model.Renk,
                    KonumId = int.Parse(model.KonumId)
                });

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        [HttpPost]
        [Route("aracSil")]
        public IActionResult AracSil([FromBody]int id)
        {
            try
            {
                aracServis.Delete(aracServis.Get(c => c.Id == id));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        [HttpGet]
        [Route("faturaGetir")]
        public IActionResult FaturaGetir(int id)
        {
            try
            {
                return Ok(faturaServis.Get(c => c.Id == id));
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        [HttpPost]
        [Route("faturaEkle")]
        public IActionResult FaturaEkle([FromBody]Arac arac)
        {
            try
            {
                faturaServis.Add(arac.Fatura);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        [HttpPost]
        [Route("faturaGuncelle")]
        public IActionResult FaturaGuncelle([FromBody] Arac arac)
        {
            try
            {
                faturaServis.Update(arac.Fatura);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }
    }
}
