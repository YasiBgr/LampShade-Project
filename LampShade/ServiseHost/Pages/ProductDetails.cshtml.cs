using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiseHost.Pages
{
    public class ProductDetailsModel : PageModel
    {
        public ProductQueryModel product;
        private readonly IProductQuery _product;

        public ProductDetailsModel(IProductQuery product)
        {
            _product = product;
        }

        public void OnGet(string id)
        {
             product = _product.GetProductDetails(id);
        }
    }
}
