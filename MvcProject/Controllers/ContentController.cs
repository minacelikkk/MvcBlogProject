using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System.Linq;
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
        public ActionResult GetAllContent(string p)
        {
            if (p == null)
            {
                var contentValues = contentManager.GetAll();
                return View(contentValues);
            }
            else
            {
                var contentValues = contentManager.GetAll(p);
                return View(contentValues.ToList());
            }
        }
    }
}