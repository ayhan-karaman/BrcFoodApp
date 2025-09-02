

using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebUI.ViewComponents.MenuViewComponents
{
    public class _MenuViewDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}