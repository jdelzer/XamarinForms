using JensCafeXamarinForms.Views;
using Xamarin.Forms;

namespace JensCafeXamarinForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            var cafeImage = new Image
            {
                Source = "cafeLogo.png",
                HeightRequest = 200,
                AutomationId = "cafeLogo"
            };

            var orderButton = new Button
            {
                Text = "Order Now",
                AutomationId = "orderButton"
            };

            var viewCartButton = new Button
            {
                Text = "View Cart",
                AutomationId = "viewCartButton"
            };

            var takeAPictureButton = new Button
            {
                Text = "Take a picture",
                AutomationId = "takePictureButton"
            };

            var goToJensCafeButton = new Button
            {
                Text = "Go To Jen's Cafe",
                AutomationId = "goToButton"
            };

            var aboutButton = new Button
            {
                Text = "About Jen's Cafe",
                AutomationId = "aboutButton"
            };

            orderButton.Clicked += OrderButton_Clicked;

            viewCartButton.Clicked += (sender, e) => { Navigation.PushAsync(new CartViewPage()); };

            takeAPictureButton.Clicked += (sender, e) => { Navigation.PushAsync(new TakePicturePage()); };

            goToJensCafeButton.Clicked += (sender, e) => { };

            aboutButton.Clicked += (sender, e) => { };

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White,
                Children =
                {
                    cafeImage,
                    orderButton,
                    viewCartButton,
                    takeAPictureButton,
                    goToJensCafeButton,
                    aboutButton
                }
            };
        }

        public void OrderButton_Clicked(object sender, System.EventArgs e)
        {
            NewTabbedPage(out var page);
        }

        public void NewTabbedPage(out TabbedPage page)
        {
            page = new TabbedPage
            {
                Title = "Menu",
                Icon = "cafeLogo",

                Children =
                {
                    new BreakfastViewPage(),
                    new LunchViewPage(),
                    new FavoritesViewPage()
                }
            };

            Navigation.PushAsync(page);

            page.CurrentPageChanged += Page_CurrentPageChanged;
        }

        private void Page_CurrentPageChanged(object sender, System.EventArgs e)
        {
            //do something
        }
    }
}