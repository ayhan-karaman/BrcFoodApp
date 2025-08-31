
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebUI.ViewComponents
{
    public class _ServiceDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}