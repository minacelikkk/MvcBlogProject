using Business.Concrete;
using Business.Validation.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Inbox()
        {
            var messageValue = messageManager.GetAllInbox();
            return View(messageValue);
        }
        public ActionResult Sendbox()
        {
            var messageValue = messageManager.GetAllSendbox();
            return View(messageValue);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var messageValues = messageManager.GetById(id);
            return View(messageValues);
        }
        [HttpPost]
        public ActionResult Add(Message message)
        {
            MessageValidator messageValidator = new MessageValidator();
            ValidationResult result = messageValidator.Validate(message);
            if (result.IsValid)
            {
                messageManager.Add(message);
                return RedirectToAction("GetAllInbox");
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
    }
}