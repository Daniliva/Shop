using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Shop.Data.interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {

        private readonly AppDBContent appDbContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDbContent, ShopCart shopCart)
        {
            this.appDbContent = appDbContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.ordeTime = DateTime.Now;
            appDbContent.Order.Add(order);
            var items = shopCart.listShopCartItems;
            foreach (var el in items)
            {
                var orderDetail = new OrderDetail
                {
                    CarID = el.car.id,
                    orderID = order.id,
                    price = el.car.price
                };
                appDbContent.OrderDetail.Add(orderDetail);

            }

            appDbContent.SaveChanges();
        }
    }
}