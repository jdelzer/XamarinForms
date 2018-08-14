using Android.OS;
using JensCafeXamarinForms.Droid;
using Plugin.Media;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JensCafeXamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TakePicturePage : ContentPage
    {
        public static Image MyImage { get; set; }

        public TakePicturePage()
        {
            InitializeComponent();
            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());

            MyImage = new Image();
            image.Source = MyImage.Source;
        }

        private async System.Threading.Tasks.Task OnTakePhotoButtonClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            MainActivity.Instance.CheckPermission();
        }
    }
}