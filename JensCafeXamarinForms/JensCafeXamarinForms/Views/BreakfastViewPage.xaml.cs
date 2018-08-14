using JensCafeXamarinForms.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JensCafeXamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BreakfastViewPage : ContentPage
    {
        public BreakfastViewPage()
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

            Title = "Breakfast";
            Icon = "breakfast";
            AutomationId = "breakfastTab";

            var menuDataService = new MenuDataService();
            MyListView = new ListView(ListViewCachingStrategy.RetainElement)
            {
                ItemsSource = menuDataService.GetItemsForGroup(1),
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(CustomCell))
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
    }
}