using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Inbox()
        {
            var messageValue = messageManager.GetAll();
            return View(messageValue);
        }
    }
}