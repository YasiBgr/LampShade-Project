using ShopManagmentAplication.Contracts.Order;
using System.Collections.Generic;

namespace _01_LampshadeQuery.Contract
{
    public interface ICartCalculatorService
    {
        Cart ComputeCart(List<CartItem> cartItems);
    }
}