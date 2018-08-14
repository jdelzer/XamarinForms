using JensCafeXamarinForms.Services;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JensCafeXamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartViewPage : ContentPage
    {
        public ObservableCollection<Models.CartItem> Items { get; set; }
        private CartDataService cartDataService;

        public CartViewPage()
        {
            InitializeComponent();

            cartDataService = new CartDataService();
            Items = new ObservableCollection<Models.CartItem>();

            MyListView.ItemsSource = cartDataService.GetCart().CartItems;

            MyListView.HasUnevenRows = true;

            TotalLabel.Text = cartDataService.GetCartTotal().ToString("C2");

            CheckoutButton.Clicked += CheckoutButton_Clicked;

            ContinueOrderingButton.Clicked += ContinueOrderingButton_Clicked;
        }

        private void ContinueOrderingButton_Clicked(object sender, System.EventArgs e)
        {
            new MainPage().NewTabbedPage(out TabbedPage page);
            Navigation.PushAsync(page);
        }

        private void CheckoutButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CheckoutPage() { Title = "Shipping Information" });
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            TotalLabel.Text = cartDataService.GetCartTotal().ToString("C2");
        }

        //private Command checkoutCommand;

        //public Command CheckoutCommand
        //{
        //    get
        //    {
        //        return checkoutCommand ?? (checkoutCommand = new Command(() =>
        //        {
        //            Navigation.PushAsync(new CheckoutPage());
        //        }));
        //    }
        //}

        //private Command goBackCommand;

        //public Command GoToMenuCommand
        //{
        //    get
        //    {
        //        return goBackCommand ?? (goBackCommand = new Command(() =>
        //        {
        //            new MainPage().NewTabbedPage(out TabbedPage page);
        //            Navigation.PushAsync(page);
        //        }));
        //    }
        //}
    }
}