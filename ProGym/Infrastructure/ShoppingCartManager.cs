using ProGym.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProGym.Models;

namespace ProGym.Infrastructure
{
    public class ShoppingCartManager
    {
        private StoreContext db;
        private ISessionManager session;
        public const string CartSessionKey = "CartSessionKey";

        public ShoppingCartManager( ISessionManager session, StoreContext db)
        {
            this.session = session;
            this.db = db;           
        }


        public void addToCart(int productId)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(p => p.Product.ProductID == productId);

            if (cartItem != null)
                cartItem.Quantity++;
            else
            {
                var productToAdd = db.Products.Where(p => p.ProductID == productId).SingleOrDefault();
                if(productToAdd != null)
                {
                    var newCartItem = new CartItem()
                    {
                        Product = productToAdd,
                        Quantity = 1,
                        TotalPrice = productToAdd.Price

                    };

                    cart.Add(newCartItem);
                }
            }

            session.Set(CartSessionKey, cart);
        }


        public List<CartItem> GetCart()
        {
            List<CartItem> cart;

            if(session.Get<List<CartItem>>(CartSessionKey)==null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = session.Get<List<CartItem>>(CartSessionKey) as List<CartItem>;
            }

            return cart;
        }


        public int RemoveFromCart(int productId)
        {
            var cart = this.GetCart();

            var cartItem = cart.Find(p => p.Product.ProductID == productId);

            if(cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    return cartItem.Quantity;
                }
                else
                    cart.Remove(cartItem);
            }

            return 0;
        }

        public decimal GetCartTotalPrice()
        {
            var cart = this.GetCart();
            return cart.Sum(p=>(p.Quantity * p.Product.Price));
        }

        public int GetCartItemsCount()
        {
            var cart = this.GetCart();
            int count = cart.Sum(p => p.Quantity);

            return count;
        }

        public Order CreateOrder(Order newOrder, string userId)
        {
            var cart = this.GetCart();

            newOrder.DateCreated = DateTime.Now;

            this.db.Orders.Add(newOrder);

            if (newOrder.OrderItems == null)
                newOrder.OrderItems = new List<OrderItem>();

            decimal cartTotal = 0;

            foreach (var cartItem in cart)
            {
                var newOrderItem = new OrderItem()
                {
                    ProductID = cartItem.Product.ProductID,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Product.Price
                };

                cartTotal += (cartItem.Quantity * cartItem.Product.Price);

                newOrder.OrderItems.Add(newOrderItem);
            }

            newOrder.TotalPrice = cartTotal;
            this.db.SaveChanges();

            return newOrder;
        }

        public void EmptyCart()
        {
            session.Set<List<CartItem>>(CartSessionKey, null);
        }
    }
}