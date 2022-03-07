using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetAll();
            return View(aboutValues);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(About about)
        {
            aboutManager.Add(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult AboutStatusUpdate(int id)
        {
            var admin = aboutManager.GetById(id);
            if (admin.AboutStatus)
            {
                admin.AboutStatus = false;
            }
            else
            {
                admin.AboutStatus = true;
            }
            aboutManager.Update(admin);
            return RedirectToAction("Index");
        }
    }
}