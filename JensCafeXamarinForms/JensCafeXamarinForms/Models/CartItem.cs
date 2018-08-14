using Xamarin.Forms;

namespace JensCafeXamarinForms.Models
{
    public class CartItem : ContentPage

    {
        public CartItem()
        {
        }

        public MenuItem Item { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }
        public double Total { get; set; }
    }
}