using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public ActionResult Index()
        {
            var skillValues = skillManager.GetAll();
            return View(skillValues);
        }
    }
}