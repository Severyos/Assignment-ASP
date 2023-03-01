using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
