using Business.Concrete;
using Business.Validation.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        [Authorize(Roles="B")]
        public ActionResult Index()
        {
            var categoryValue = cm.GetAll();
            return View(categoryValue);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                cm.Add(category);
                return RedirectToAction("Index");
            }       
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var categoryValue = cm.GetById(id);
            cm.Delete(categoryValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var categoryValue = cm.GetById(id);
            return View(categoryValue);

        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            cm.Update(category);
            return RedirectToAction("Index");
        }
    }
}