using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test2()
        {
            return View();
        }
    }
}