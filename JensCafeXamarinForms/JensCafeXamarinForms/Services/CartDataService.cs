using JensCafeXamarinForms.Models;
using JensCafeXamarinForms.ViewModels;

namespace JensCafeXamarinForms.Services
{
    public class CartDataService
    {
        private static CartRepository cartRepository = new CartRepository();

        public CartDataService()
        {
        }

        public void AddCartItem(MenuItem menuItem, int amount, double price)
        {
            cartRepository.AddCartItem(menuItem, amount, price);
        }

        public double GetCartTotal()
        {
            return cartRepository.GetCartTotal();
        }

        public Cart GetCart()
        {
            return cartRepository.GetCart();
        }
    }
}