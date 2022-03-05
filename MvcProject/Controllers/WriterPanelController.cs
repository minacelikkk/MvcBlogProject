using Business.Concrete;
using Business.Validation.FluentValidation;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        Context context = new Context();
        public ActionResult WriterProfile()
        {
            int id;
            string mail = (string)Session["WriterMail"];
            id= context.Writers.Where(w => w.WriterMail == mail).Select(w => w.WriterId).FirstOrDefault();
            var writerValues = writerManager.GetById(id);
            return View(writerValues);
        }
        [HttpPost]
        public ActionResult Update(Writer writer)
        {
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                writerManager.Update(writer);
                return RedirectToAction("AllHeading","WriterPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult MyHeading(string mail)
        {
            mail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(w => w.WriterMail == mail).Select(w => w.WriterId).FirstOrDefault();
            var headingValues = headingManager.GetAllByWriter(writerIdInfo);
            return View(headingValues);
        }
        public ActionResult AllHeading(int page=1)
        {
            var headingValues = headingManager.GetAll().ToPagedList(page,4);
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> categoryValue = (from c in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.categoryValue = categoryValue;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writerMailInfo = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(w => w.WriterMail == writerMailInfo).Select(w => w.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerIdInfo;
            heading.HeadingStatus = true;
            headingManager.Add(heading);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> categoryValue = (from c in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.categoryValue = categoryValue;
            var headingValue = headingManager.GetById(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult Update(Heading heading)
        {
            headingManager.Update(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult Delete(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.HeadingStatus = false;
            headingManager.Delete(headingValue);
            return RedirectToAction("MyHeading");
        }
    }
}