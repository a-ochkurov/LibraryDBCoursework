using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Web.Controllers
{
    public class GenresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}