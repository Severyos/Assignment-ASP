using Assignment.Models.Forms;
using Assignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class RegisterController : Controller
    {

        private readonly AuthService _auth;

        public RegisterController(AuthService auth)
        {
            _auth = auth;
        }

        public IActionResult Index(string ReturnUrl = null!)
        {
            var form = new RegisterForm { ReturnUrl = ReturnUrl ?? Url.Content("~/") };
            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.RegisterAsync(form))
                    return LocalRedirect(form.ReturnUrl!);
                else
                    return View();
            }

            return View();
        }
    }
}
