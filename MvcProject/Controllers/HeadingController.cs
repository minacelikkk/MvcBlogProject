using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingValues = headingManager.GetAll();
            return View(headingValues);
        }
        public ActionResult HeadingReport()
        {
            var headingValues = headingManager.GetAll();
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> categoryValue = (from c in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()
                                                  }).ToList();
            List<SelectListItem> writerValue = (from w in writerManager.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = w.WriterFirstName +" "+ w.WriterSurname,
                                                    Value = w.WriterId.ToString()

                                                }).ToList();
            ViewBag.categoryValue = categoryValue;
            ViewBag.writerValue = writerValue;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.Add(heading);
            return RedirectToAction("Index");   
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
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.HeadingStatus = false;
            headingManager.Delete(headingValue);
            return RedirectToAction("Index");
        }
        public ActionResult HeadingStatusUpdate(int id)
        {
            var headingStatus=headingManager.GetById(id);
            if (headingStatus.HeadingStatus)
            {
                headingStatus.HeadingStatus = false;
            }
            else
            {
                headingStatus.HeadingStatus = true;
            }
            headingManager.Update(headingStatus);
            return RedirectToAction("Index");
        }
    }
}