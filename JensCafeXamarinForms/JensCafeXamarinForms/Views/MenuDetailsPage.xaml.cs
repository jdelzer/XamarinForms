using JensCafeXamarinForms.Services;
using JensCafeXamarinForms.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JensCafeXamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuDetailsPage : ContentPage
    {
        private Models.MenuItem menuItem { get; }

        public MenuDetailsPage(Models.MenuItem menuItem) : base()
        {
            InitializeComponent();

            this.menuItem = menuItem;

            BindingContext = this.menuItem;

            mySwitch.IsToggled = this.menuItem.IsFavorite;

            this.CancelButton.Clicked += CancelButton_ClickedAsync;

            this.OrderButton.Clicked += OrderButton_Clicked;

            OnPropertyChanged();
        }

        protected sealed override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
        }

        private async void OrderButton_Clicked(object sender, System.EventArgs e)
        {
            var result = await DisplayAlert("Confirmation", $"You've added {this.entryAmount.Text} {this.menuItem.Name} to your cart",
                "View Cart", "Continue Ordering");
            if (result)
                DisplayCart();
            else
            {
                new MainPage().NewTabbedPage(out var page);
                await Navigation.PushAsync(page);
            }

            AddToCart(this.menuItem, Int32.Parse(entryAmount.Text), this.menuItem.Price);
        }

        private async void CancelButton_ClickedAsync(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnToggled(object sender, ToggledEventArgs e)
        {
            bool isToggled = e.Value;
            if (isToggled)
            {
                likeImage.Source = "like";
                menuItem.IsFavorite = true;
            }
            else
            {
                likeImage.Source = "likeWhite";
                menuItem.IsFavorite = false;
            }
        }

        private void AddToCart(Models.MenuItem item, int amount, double price)
        {
            CartDataService cartDataService = new CartDataService();
            cartDataService.AddCartItem(item, amount, price);
        }

        private async void DisplayCart()
        {
            await Navigation.PushAsync(new CartViewPage());
        }
    }
}