using System.Web.Mvc;

namespace FYP.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SupervisorMessage()
        {
            return View();
        }
    }
}
