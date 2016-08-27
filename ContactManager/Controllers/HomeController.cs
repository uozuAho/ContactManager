using System.Web.Mvc;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult ContactWithAuth()
        {
            ViewBag.Message = "If you're seeing this, you're authorised. Congrats!";
            return View();
        }
    }
}