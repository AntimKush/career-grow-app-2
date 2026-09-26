using Microsoft.AspNetCore.Mvc;

namespace Career_Growth_App_2._0.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
