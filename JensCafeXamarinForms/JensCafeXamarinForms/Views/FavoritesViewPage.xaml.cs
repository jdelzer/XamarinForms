using JensCafeXamarinForms.Services;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ListView = Xamarin.Forms.ListView;

namespace JensCafeXamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesViewPage : ContentPage
    {
        public IEnumerable<Models.MenuItem> Items { get; set; }

        private MenuDataService menuDataService;

        public FavoritesViewPage()
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Padding = new Thickness(0, 20, 0, 0);
                    break;

                case Device.Android:
                    break;
            }

            Title = "Favorites";
            Icon = "like";
            AutomationId = "favoritesTab";

            menuDataService = new MenuDataService();
            MyListView = new ListView(ListViewCachingStrategy.RecycleElement)
            {
                ItemsSource = menuDataService.GetFavoriteItems(),
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(CustomCell)),
                IsPullToRefreshEnabled = true
            };

            Content = MyListView;

            // Handle item tapped
            MyListView.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    await Navigation.PushAsync(new MenuDetailsPage(e.SelectedItem as Models.MenuItem));
                    //Deselect Item
                    ((ListView)sender).SelectedItem = null;
                }
            };
        }

        protected override void OnAppearing()
        {
            MyListView.ItemsSource = menuDataService.GetFavoriteItems();
        }
    }
}