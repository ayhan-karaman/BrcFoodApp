

using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebUI.ViewComponents
{
    public class _FooterDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}