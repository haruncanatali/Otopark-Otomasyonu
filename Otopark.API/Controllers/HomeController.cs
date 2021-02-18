using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Otapark.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otopark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        IKonumService konumServis;
        public HomeController(IKonumService x)
        {
            konumServis = x;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(konumServis.List());
        }

        [HttpGet]
        [Route("bosYerler")]
        public IActionResult BosYerleriGetir()
        {
            return Ok(konumServis.List(c=>c.Durum == false));
        }

        [HttpGet]
        [Route("konumGetir")]
        public IActionResult KonumGetir(string id)
        {
            return Ok(konumServis.Get(c => c.Arac.Id == int.Parse(id)));
        }

    }
}
