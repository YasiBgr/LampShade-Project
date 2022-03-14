using _01_LampshadeQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;

namespace ServiseHost.ViewComponents
{
    public class LatestArrivalsViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public LatestArrivalsViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var product = _productQuery.GetLatestArrivals();
            return View(product);
        }
    }
}
