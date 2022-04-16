﻿using System.Collections.Generic;
using _0_FramBase.Application;
using Microsoft.Extensions.Configuration;

using ShopManagment.Domain.OrderAgg;
using ShopManagmentAplication.Contracts.Order;

namespace ShopManagment.Aplication
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IConfiguration _configuration;
        private readonly IOrderRepository _orderRepository;
       // private readonly IShopInventoryAcl _shopInventoryAcl;
      //  private readonly ISmsService _smsService;
       // private readonly IShopAccountAcl _shopAccountAcl;

        public OrderApplication(IOrderRepository orderRepository, IAuthHelper authHelper, IConfiguration configuration
           )
        {
            _orderRepository = orderRepository;
            _authHelper = authHelper;
            _configuration = configuration;
           
  
           // _shopAccountAcl = shopAccountAcl;
        }

        public long PlaceOrder(Cart cart)
        {
            var currentAccountId = _authHelper.CurrentAccountId();
            var order = new Order(currentAccountId, cart.PaymentMethod, cart.TotalAmount, cart.DiscountAmount,
                cart.PayAmount);

            foreach (var cartItem in cart.Items)
            {
                var orderItem = new OrderItem(cartItem.Id, cartItem.Count, cartItem.UnitPrice, cartItem.DiscountRate);
                order.AddItem(orderItem);
            }

            _orderRepository.Create(order);
            _orderRepository.Save();
            return order.Id;
        }

        public double GetAmountBy(long id)
        {
            return _orderRepository.GetAmountBy(id);
        }

        public void Cancel(long id)
        {
            var order = _orderRepository.Get(id);
            order.Cancel();
            _orderRepository.Save();
        }

        //public string PaymentSucceeded(long orderId, long refId)
        //{
        //    var order = _orderRepository.Get(orderId);
        //    order.PaymentSucceeded(refId);
        //    var symbol = _configuration.GetValue<string>("Symbol");
        //    var issueTrackingNo = CodeGenerator.Generate(symbol);
        //    order.SetIssueTrackingNo(issueTrackingNo);
        // //   if (!_shopInventoryAcl.ReduceFromInventory(order.Items)) return "";

        //    _orderRepository.Save();

        //  //  var (name, mobile) = _shopAccountAcl.GetAccountBy(order.AccountId);

        //    //_smsService.Send(mobile,
        //    //    $"{name} گرامی سفارش شما با شماره پیگیری {issueTrackingNo} با موفقیت پرداخت شد و ارسال خواهد شد.");
        //    return issueTrackingNo;
        //}

        public List<OrderItemViewModel> GetItems(long orderId)
        {
            return _orderRepository.GetItems(orderId);
        }

        public List<OrderViewModel> Search(OrderSearchModel searchModel)
        {
            return _orderRepository.Search(searchModel);
        }
    }
}