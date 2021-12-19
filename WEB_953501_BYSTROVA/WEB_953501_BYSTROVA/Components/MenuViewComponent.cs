using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953501_BYSTROVA.Models;
using Microsoft.AspNetCore.Identity;

namespace WEB_953501_BYSTROVA.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private UserManager<ApplicationUser> _userManager;

        public MenuViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<MenuItem> menus = new List<MenuItem>
            {
                new MenuItem{Controller = "Product", Action = "Index", Text = "Каталог"},
                //new MenuItem{IsPage = true, Area = "Admin", Page = "/Index", Text = "Администрирование"}
            };

            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(User.Identity.Name);
                if(user != null && await _userManager.IsInRoleAsync(user, "admin"))
                {
                    menus.Add(new MenuItem { IsPage = true, Area = "Admin", Page = "/Index", Text = "Администрирование" });
                }
            }

            string controller = (string)ViewContext.RouteData.Values["controller"];
            string action = (string)ViewContext.RouteData.Values["action"];
            string page = (string)ViewContext.RouteData.Values["page"];
            string area = (string)ViewContext.RouteData.Values["area"];
            foreach (MenuItem menuItem in menus)
            {
                if((menuItem.Controller == controller && menuItem.Action == action) ||
                    (menuItem.Area == area && menuItem.Page == page))
                {
                    menuItem.Active = "active";
                    break;
                }
            }
            return View(menus);
        }

    }
}
