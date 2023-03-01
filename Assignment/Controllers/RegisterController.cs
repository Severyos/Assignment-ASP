using Assignment.Models.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index(string ReturnUrl = null!)
        {
            var form = new RegisterForm { ReturnUrl = ReturnUrl ?? Url.Content("~/") };
            return View(form);
        }

        [HttpPost]
        public IActionResult Index(RegisterForm form)
        {
            return View();
        }
    }
}
