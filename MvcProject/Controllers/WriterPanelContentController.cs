using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        public ActionResult MyContent(string mail)
        {
            mail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(w => w.WriterMail == mail).Select(w => w.WriterId).FirstOrDefault();
            var contentValues = contentManager.GetAllByWriter(writerIdInfo);
            return View(contentValues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.headingId = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(w => w.WriterMail == mail).Select(w => w.WriterId).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.ContentStatus = true;
            contentManager.Add(content);
            return RedirectToAction("MyContent");
        }
    }
}