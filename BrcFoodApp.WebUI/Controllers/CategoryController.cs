
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebUI.Controllers
{

    [Route("[controller]")]
    public class CategoryController : Controller
    {

        public IActionResult CategoryList()
        {
            return View();
        }
    }
}