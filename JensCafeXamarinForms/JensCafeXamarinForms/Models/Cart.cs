using System.Collections.ObjectModel;

namespace JensCafeXamarinForms.Models
{
    public class Cart
    {
        public Cart()
        {
        }

        public ObservableCollection<CartItem> CartItems
        {
            get;
            set;
        }
    }
}