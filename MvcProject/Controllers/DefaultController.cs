using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
     [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public PartialViewResult Index(int id=0)
        {
            var contentValues = contentManager.GetAllByHeadingId(id);
            return PartialView(contentValues);
        }
        public ActionResult Headings()
        {
            var headingValues = headingManager.GetAll();
            return View(headingValues);
        }
    }
}