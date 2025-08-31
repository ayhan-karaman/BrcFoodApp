
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebUI.ViewComponents
{
    public class _NavbarDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}