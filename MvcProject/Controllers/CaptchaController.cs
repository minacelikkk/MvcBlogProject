using MvcProject.Models;
using Newtonsoft.Json;
using System.Net;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class CaptchaController : Controller
    {
        [HttpPost]
        public ActionResult FormSubmit()
        {
            var response = Request["g-recaptcha-response"];
            const string secretKey = "6LdO8bAeAAAAAOGACgs1QDSCxy7SIDy3LVurZjcg";//secret key
            var client = new WebClient();
            var reply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);
            if (!captchaResponse.Success)
                TempData["Message"] = "Lütfen güvenliği doğrulayınız.";
            else
                TempData["Message"] = "Güvenlik başarıyla doğrulanmıştır.";
            return RedirectToAction("Index");
        }
    }
}



