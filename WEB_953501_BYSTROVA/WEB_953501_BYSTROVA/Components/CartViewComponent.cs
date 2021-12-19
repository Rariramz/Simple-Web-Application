using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_953501_BYSTROVA.Models;
using WEB_953501_BYSTROVA.Extensions;

namespace WEB_953501_BYSTROVA.Components
{
    public class CartViewComponent : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            Cart cart = HttpContext.Session.Get<Cart>("cart");
            return View(cart);
        }
    }
}
