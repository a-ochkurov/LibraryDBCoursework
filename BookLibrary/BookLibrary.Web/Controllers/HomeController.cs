using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}