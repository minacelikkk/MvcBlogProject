using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetAllByHeadingId(id);
            return View(contentValues);
        }
    }
}