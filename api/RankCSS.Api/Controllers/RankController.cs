using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RankCSS.Business.Dominio;

namespace RankCSS.Api.Controllers
{
    public class RankController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("RankGeral")]
        public JsonResult RankGeral()
        {
            var log = new Log();
            var retorno = log.LerAquivoLogTxt();

            return Json(retorno);
        }

    }

}