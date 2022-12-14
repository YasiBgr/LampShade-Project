using System.Collections.Generic;
using _0_FramBase.Domain;
using ShopManagmentAplication.Contracts.Order;

namespace ShopManagment.Domain.OrderAgg
{
    public interface IOrderRepository : IRepository<long, Order>
    {
        double GetAmountBy(long id);
        List<OrderItemViewModel> GetItems(long orderId);
        List<OrderViewModel> Search(OrderSearchModel searchModel);
    //    List<OrderViewModel> paidList();
    }
}