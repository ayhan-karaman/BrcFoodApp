

using Microsoft.AspNetCore.Mvc;

namespace BrcFoodApp.WebUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _SidebarAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}