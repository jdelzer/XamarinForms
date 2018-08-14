using Xamarin.Forms;

namespace JensCafeXamarinForms
{
    public class CustomCell : ViewCell
    {
        private Image logoImage;
        private Label nameLabel, shortDescriptionLabel, priceLabel;
        private StackLayout verticaLayout = new StackLayout();

        public CustomCell()
        {
            logoImage = new Image
            {
                WidthRequest = 50,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Margin = 5,
                AutomationId = "logoImage"
            };

            logoImage.SetBinding(Image.SourceProperty, "ImagePath");

            nameLabel = new Label
            {
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Start,
                Margin = new Thickness(10, 0, 8, 0),
                AutomationId = "nameLabel"
            };

            nameLabel.SetBinding(Label.TextProperty, "Name");

            shortDescriptionLabel = new Label
            {
                FontSize = 12,
                TextColor = Color.Black,
                Margin = new Thickness(10, 0, 8, 0),
                VerticalTextAlignment = TextAlignment.End,
                HorizontalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.Start,
                AutomationId = "shortDescriptionLabel"
            };
            shortDescriptionLabel.SetBinding(Label.TextProperty, "ShortDescription");

            priceLabel = new Label
            {
                FontSize = 14,
                TextColor = Color.Black,
                Margin = new Thickness(3, 0, 0, 0),
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalTextAlignment = TextAlignment.Center,
                LineBreakMode = LineBreakMode.NoWrap,
                AutomationId = "priceLabel"
            };
            priceLabel.SetBinding(Label.TextProperty, "Price", stringFormat: "{0:C}");

            verticaLayout.Orientation = StackOrientation.Vertical;
            verticaLayout.VerticalOptions = LayoutOptions.Center;

            verticaLayout.Children.Add(nameLabel);
            verticaLayout.Children.Add(shortDescriptionLabel);

            View = new StackLayout
            {
                Children = { logoImage, verticaLayout, priceLabel },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(5, 0, 5, 0),
                BackgroundColor = Color.FromHex("#f1e5c1"),
                AutomationId = "Menu"
            };
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            //logoImage.Source = ImagePath;
            //nameLabel.Text = Name;
            //shortDescriptionLabel.Text = ShortDescription;
            //priceLabel.Text = Price;
        }

        //StackLayout cellWrapper = new StackLayout();
        //StackLayout horizontalLayout = new StackLayout();
        //horizontalLayout.Children.Add(logoImage);
        //horizontalLayout.Children.Add(nameLabel);
        //horizontalLayout.Children.Add(shortDescriptionLabel);
        //horizontalLayout.Children.Add(priceLabel);

        //cellWrapper.Children.Add(horizontalLayout);

        //View = cellWrapper;
    }
}