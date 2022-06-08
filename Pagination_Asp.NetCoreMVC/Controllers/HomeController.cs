using Microsoft.AspNetCore.Mvc;

namespace Pagination_Asp.NetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        Database_Access_layer.db dbop = new Database_Access_layer.db();
        public IActionResult Index()
        {
            return View(dbop.GetProduct(1));
        }

        [HttpPost]
        public IActionResult Index(int currentPageIndex)
        {
            return View(dbop.GetProduct(currentPageIndex));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your Application description page";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page";
            return View();
        }
    }
}
