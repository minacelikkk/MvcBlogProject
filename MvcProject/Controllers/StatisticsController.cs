using DataAccess.Concrete;
using System.Linq;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            //Toplam Kategori Sayisi
            var totalCategory = context.Categories.Count();
            ViewBag.totalNumberOfCategories = totalCategory;

            // Yazilim Kategorisi (9) baslik sayisi
            var softwareCategory = context.Headings.Count(h => h.CategoryId == 9);
            ViewBag.softwareCategoryTitleNumber = softwareCategory;

            // Yazar adinda "a" harfi gecen yazar sayisi
            var writerFirstNameSortByA = context.Writers.Count(w => w.WriterFirstName.Contains("a")); 
            ViewBag.writerFirstNameSortByA = writerFirstNameSortByA;

            // En fazla basliga sahip kategori adi
            var mostTitles = context.Headings.Max(c => c.Category.CategoryName); 
            ViewBag.categoryNameWithTheMostTitles = mostTitles;

            // Kategoriler tablosundaki aktif kategori sayisi
            var categoryStatusTrue = context.Categories.Count(c => c.CategoryStatus == true);
            ViewBag.activeCategories = categoryStatusTrue;

            return View();
        }

    }
}
