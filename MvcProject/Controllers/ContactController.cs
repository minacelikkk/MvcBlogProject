using Business.Concrete;
using Business.Validation.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator contactValidator = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = contactManager.GetAll();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetById(id);
            return View(contactValues);
        }
        public PartialViewResult MessageListMenu(string mail)
        {
            ViewBag.ContactCount = contactManager.GetAll().Count;
            ViewBag.InboxMessageCount = messageManager.GetAllInbox(mail).Count;
            ViewBag.SendboxMessageCount = messageManager.GetAllSendbox(mail).Count;
            return PartialView();
        }
    }
}