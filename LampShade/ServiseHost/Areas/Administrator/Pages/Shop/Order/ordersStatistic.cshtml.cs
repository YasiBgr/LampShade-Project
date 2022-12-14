using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contract.Orders;
using _01_LampshadeQuery.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagmentAplication.Contracts.Order;
using ShopManagmentAplication.Contracts.ProductCategory.folder;

namespace ServiseHost.Areas.Administrator.Pages.Shop.Order
{
    public class ordersStatisticModel : PageModel
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        private readonly IOrderQuery _orderQuery;
        private readonly IOrderApplication _orderApplication;
        public long productCount { get; set; }
        public List<ProductCategoryQueryModel> category { get; set; }
        public List<ProductCategoryQueryModel> productsByCategory { get; set; }
        public List<OrderViewModel> orders { get; set; }
        public ordersStatisticModel(IProductCategoryQuery productCategoryQuery, IOrderQuery orderQuery, IOrderApplication orderApplication)
        {
            _productCategoryQuery = productCategoryQuery;
            _orderQuery = orderQuery;
            _orderApplication = orderApplication;
        }

        public void OnGet(OrderSearchModel searchModel)
        {
            category = _productCategoryQuery.GetListProductCategory();
            productsByCategory = _productCategoryQuery.GetProductCategoryWithProducts();
            orders = _orderApplication.Search(searchModel);

            foreach (var order in orders)
            {
                var orderid = order.Id;
                foreach (var product in productsByCategory)
                {
                    var productid = product.Id;

                     productCount = _orderQuery.GeProductOrderCount(orderid, productid);
                }
            }
        }
    }
}
