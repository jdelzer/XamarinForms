using JensCafeXamarinForms.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JensCafeXamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LunchViewPage : ContentPage
    {
        private MenuDataService menuDataService;

        public LunchViewPage()
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

            Title = "Lunch";
            Icon = "sandwich";
            AutomationId = "lunchTab";

            menuDataService = new MenuDataService();
            MyListView = new ListView()
            {
                ItemsSource = menuDataService.GetItemsForGroup(2),
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(CustomCell)),
            };

            Content = MyListView;

            // Handle item tapped
            MyListView.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    Navigation.PushAsync(new MenuDetailsPage(e.SelectedItem as Models.MenuItem));

                    //Deselect Item
                    ((ListView)sender).SelectedItem = null;
                }
            };
        }
    }
}