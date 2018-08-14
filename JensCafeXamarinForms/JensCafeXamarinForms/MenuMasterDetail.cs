using JensCafeXamarinForms.Services;
using Xamarin.Forms;

namespace JensCafeXamarinForms
{
    public class MenuMasterDetail : MasterDetailPage
    {
        private MenuDataService menuDataService;

        public MenuMasterDetail()
        {
            var listView = new ListView();
            menuDataService = new MenuDataService();
            // listView.ItemsSource = menuDataService.GetAllItems();

            Master = new TabbedPage()
            {
                Children =
                {
                    new BreakfastViewPage(),
                    new LunchViewPage(),
                    new FavoritesViewPage()
                }
            };

            Master.Title = "Menu";
            Master.Icon = "cafelogo.png";

            //listView.ItemSelected += (sender, e) =>
            //{
            //    if (e.SelectedItem != null)
            //    {
            //        Detail.BindingContext = e.SelectedItem;

            //        IsPresented = false;
            //    }
            //};

            //Master = new ContentPage
            //{
            //    Title = "Menu",
            //    Icon = "cafeLogo",
            //    Content = listView
            //};

            Detail = Master;

            Navigation.PushAsync(Master);
        }
    }
}