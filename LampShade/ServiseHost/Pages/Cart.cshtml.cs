using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagmentAplication.Contracts.Order;

namespace ServiseHost.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItem> CartItem;
        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies["cart_Items"];
            CartItem = serializer.Deserialize<List<CartItem>>(value);
            foreach (var item in CartItem)
            {
                item.TotalItemPrice = item.UnitPrice * item.Count;
            }
        }
    }
}
