using Business.Concrete;
using Business.Validation.FluentValidation;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageValue = messageManager.GetAllInbox(mail);
            return View(messageValue);
        }
        public ActionResult Sendbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageValue = messageManager.GetAllSendbox(mail);
            return View(messageValue);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var messageValues = messageManager.GetById(id);
            return View(messageValues);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var messageValues = messageManager.GetById(id);
            return View(messageValues);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Message message)
        {
            string mail = (string)Session["WriterMail"];
            ValidationResult result = messageValidator.Validate(message);
                if (result.IsValid)
                {
                    message.SenderMail = mail;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.Add(message);
                    return RedirectToAction("Sendbox");
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