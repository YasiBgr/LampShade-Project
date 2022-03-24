using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagmentAplication.Contracts.Comment.folder;

namespace ServiseHost.Pages
{
    public class ProductDetailsModel : PageModel
    {
        public ProductQueryModel product;
        private readonly IProductQuery _product;
        private readonly ICommentApplication _comment ;

        public ProductDetailsModel(IProductQuery product, ICommentApplication comment)
        {
            _product = product;
           _comment = comment;
        }

        public void OnGet(string id)
        {
             product = _product.GetProductDetails(id);
        }
        public IActionResult OnPost(AddComment comment,string productSlug)
        {
         var result=_comment.AddComment(comment);
            return RedirectToPage("./ProductDetails", new { Id = productSlug });
        }
    }
}
