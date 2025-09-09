
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebUI.Controllers
{
    [Route("[controller]")]
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}