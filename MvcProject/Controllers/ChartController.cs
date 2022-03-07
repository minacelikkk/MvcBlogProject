using DataAccess.Concrete;
using MvcProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
    public List<Category> BlogList()
    {
        List<Category> category = new List<Category>();
        category.Add(new Category()
        {
            CategoryName = "Yazılım",
            CategoryCount = 8
        });
        category.Add(new Category()
        {
            CategoryName = "Seyahat",
            CategoryCount = 4
        });
        category.Add(new Category()
        {
            CategoryName = "Teknoloji",
            CategoryCount = 7
        });
        category.Add(new Category()
        {
            CategoryName = "Spor",
            CategoryCount = 1
        });
        return category;

    }
}
}