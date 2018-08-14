using JensCafeXamarinForms.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace JensCafeXamarinForms.ViewModels
{
    public class CartRepository
    {
        public CartRepository()
        {
        }

        private static Cart MainCart = new Cart() { CartItems = new ObservableCollection<CartItem>() };

        public void AddCartItem(MenuItem item, int amount, double price)
        {
            var cartItem = new CartItem() { Item = item, Amount = amount, Price = price };

            if (MainCart.CartItems.All(x => x.Item.ItemId != cartItem.Item.ItemId))
                MainCart.CartItems.Add(cartItem);
            else
            {
                var updateItemAmount = MainCart.CartItems.FirstOrDefault(x => x.Item.ItemId == cartItem.Item.ItemId);
                updateItemAmount.Amount += amount;
            }
        }

        public Cart GetCart()
        {
            return MainCart;
        }

        public double GetCartTotal()
        {
            var totalPrice = MainCart.CartItems.Sum(x => x.Price * x.Amount);
            return totalPrice;
        }
    }
}