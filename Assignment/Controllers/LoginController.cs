using Assignment.Models.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index(string ReturnUrl = null!)
        {
            var form = new LoginForm { ReturnUrl = ReturnUrl ?? Url.Content("~/") };
            return View(form);
        }

        [HttpPost]
        public IActionResult Index(LoginForm form)
        {
            return View();
        }
    }
}
