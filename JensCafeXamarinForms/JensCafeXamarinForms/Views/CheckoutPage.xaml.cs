using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JensCafeXamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckoutPage : ContentPage
    {
        public CheckoutPage()
        {
            var layout = new RelativeLayout() { Margin = new Thickness(5), AutomationId = "checkoutPageLayout" };

            var creditCardImage = new Image
            {
                Source = "creditcards.png",
                HorizontalOptions = LayoutOptions.Center
            };

            var firstNameEntry = new Entry
            {
                Placeholder = "First Name",
                WidthRequest = 180,
                BackgroundColor = Color.White,
                MaxLength = 100,
                AutomationId = "firstNameEntry"
            };
            var lastNameEntry = new Entry
            {
                Placeholder = "Last Name",
                WidthRequest = 180,
                BackgroundColor = Color.White,
                MaxLength = 200,
                AutomationId = "lastNameEntry"
            };
            var streetAddressEntry = new Entry
            {
                Placeholder = "Street Address",
                WidthRequest = 180,
                BackgroundColor = Color.White,
                MaxLength = 200,
                AutomationId = "streetAddressEntry"
            };
            var cityEntry = new Entry
            {
                Placeholder = "City",
                WidthRequest = 180,
                BackgroundColor = Color.White,
                MaxLength = 100,
                AutomationId = "cityNameEntry"
            };
            var statePicker = new Picker
            {
                ItemsSource = StateList,
                Title = "State",
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 60,
                AutomationId = "statePicker"
            };
            var zipEntry = new Entry
            {
                Placeholder = "Zip Code",
                WidthRequest = 180,
                BackgroundColor = Color.White,
                MaxLength = 5,
                Keyboard = Keyboard.Numeric,
                AutomationId = "zipCodeEntry"
            };
            var phoneEntry = new Entry
            {
                Placeholder = "Phone",
                WidthRequest = 180,
                BackgroundColor = Color.White,
                MaxLength = 11,
                Keyboard = Keyboard.Telephone,
                AutomationId = "phoneEntry"
            };

            var goToPaymentButton = new Button
            {
                Text = "Continue to Payment",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 300,
                Margin = new Thickness(0, 10, 0, 5),
                AutomationId = "goToPaymentButton"
            };

            layout.Children.Add(creditCardImage, Constraint.Constant(35));

            //Layout below image
            layout.Children.Add(firstNameEntry,
                Constraint.RelativeToView(creditCardImage, (p, otherView) => otherView.X - 27),
                Constraint.RelativeToView(creditCardImage, (p, otherView) => otherView.Y + otherView.Height));

            //Layout to right of last name
            layout.Children.Add(lastNameEntry, Constraint.RelativeToView(firstNameEntry, (p, otherView) => otherView.X + otherView.Width),
                Constraint.RelativeToView(firstNameEntry, (p, otherView) => otherView.Y));

            //Layout under first name
            layout.Children.Add(streetAddressEntry, Constraint.RelativeToView(firstNameEntry, (p, otherView) => otherView.X),
                Constraint.RelativeToView(firstNameEntry, (p, otherView) => otherView.Y + otherView.Height));

            //Layout to right of street address
            layout.Children.Add(cityEntry, Constraint.RelativeToView(streetAddressEntry, (p, otherView) => otherView.X + otherView.Width),
                Constraint.RelativeToView(streetAddressEntry, (p, otherView) => otherView.Y));

            //Layout under street address
            layout.Children.Add(statePicker, Constraint.RelativeToView(streetAddressEntry, (p, otherView) => otherView.X),
                Constraint.RelativeToView(streetAddressEntry, (p, otherView) => otherView.Y + otherView.Height));

            //Layout to right of state picker
            layout.Children.Add(zipEntry, Constraint.RelativeToView(streetAddressEntry, (p, otherView) => otherView.X + otherView.Width),
                Constraint.RelativeToView(statePicker, (p, otherView) => otherView.Y));

            //Layout under state
            layout.Children.Add(phoneEntry, Constraint.RelativeToView(statePicker, (p, otherView) => otherView.X),
                Constraint.RelativeToView(statePicker, (p, otherView) => otherView.Y + otherView.Height));

            layout.Children.Add(goToPaymentButton, Constraint.Constant(0),
                Constraint.RelativeToParent(p => p.Height / 2),
                Constraint.RelativeToView(creditCardImage, (p, otherView) => p.X + p.Width));

            Content = layout;
        }

        public static string[] StateList { get; set; } = new string[] {
            "AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DC", "DE", "FL", "GA", "GU",
            "HI", "IA", "ID", "IL", "IN", "KS", "KY", "LA", "MA", "MD", "ME", "MH", "MI", "MN", "MO", "MS", "MT", "NC",
            "ND", "NE", "NH", "NJ", "NM", "NV", "NY", "OH", "OK", "OR", "PA", "PR", "PW", "RI", "SC", "SD", "TN", "TX",
            "UT", "VA", "VI", "VT", "WA", "WI", "WV", "WY"};
    }
}