using System.Web.Mvc;

namespace FYP.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PreviousProjects()
        {
            return View();
        }
        public ActionResult CurrentProjects()
        {
            return View();
        }
    }
}
