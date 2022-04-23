using _01_LampshadeQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ShopManagment.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductQuery _productQuery;

        public ProductController(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }
        [HttpGet]
        public List<ProductQueryModel> GetLatestArrivals()
        {
            return _productQuery.GetLatestArrivals();
        }
    }
}
