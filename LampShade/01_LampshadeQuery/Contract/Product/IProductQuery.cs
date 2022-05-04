using System.Collections.Generic;
using ShopManagmentAplication.Contracts.Order;

namespace _01_LampshadeQuery.Contract.Product
{
    public interface IProductQuery
    {
        List<ProductQueryModel> GetLatestArrivals();
       ProductQueryModel  GetProductDetails(string slug);
        List<ProductQueryModel> Search(string value);
        List<CartItem> CheckInventoryStatus(List<CartItem> cartItems);
        List<ProductQueryModel> GetListProduct();


    }
}
