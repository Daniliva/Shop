using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Model;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDbContent;

        public ShopCart(AppDBContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public string ShopCarId { get; set; }
        public List<ShopCartItem> listShopCartItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCarId = shopCartId };
        }

        public void AddToCart(Car car)
        {
            this.appDbContent.ShopCartItem.Add(new ShopCartItem()
            {
                ShopCartId = ShopCarId,
                car = car,
                price = car.price
            });
            appDbContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {
            return appDbContent.ShopCartItem.Where(c => c.ShopCartId == ShopCarId).Include(s => s.car).ToList();
        }
    }
}