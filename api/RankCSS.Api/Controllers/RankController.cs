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

        [HttpGet, Route("RankDiario")]
        public JsonResult RankDiario()
        {
            try
            {
                var log = new Log();
                var lstRankDiario = log.LerAquivoLogTxt();

                return Json(lstRankDiario);
            }
            catch
            {
                return null;
            }
        }

    }

}