using System.Web.Mvc;

namespace Cer.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Cer.WebApi";

            return View();
        }
    }
}
 