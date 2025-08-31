
using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebUI.ViewComponents
{
    public class _AboutDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}