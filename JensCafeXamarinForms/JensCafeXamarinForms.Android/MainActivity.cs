using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Java.IO;
using Plugin.Media;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JensCafeXamarinForms.Droid
{
    [Activity(Label = "JensCafeXamarinForms", Icon = "@mipmap/cafelogo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public File imageDirectory;
        public File imageFile;
        public Image pictureImageView;

        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Instance = this;

            imageDirectory = new File(Android.OS.Environment
                .GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "JensCafeImages");

            if (!imageDirectory.Exists())
            {
                imageDirectory.Mkdirs();
            }

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            TakePicturePage.MyImage.Source = SetImageSourceAsync().Result.Source;

            //required to avoid memory leaks
            GC.Collect();
        }

        public async Task<Image> SetImageSourceAsync()
        {
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = MainActivity.Instance.imageDirectory.Path,
                Name = Instance.imageFile.Name
            });

            pictureImageView.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

            return pictureImageView;
        }

        public void CheckPermission()
        {
            var permissionCheck = ContextCompat.CheckSelfPermission(Android.App.Application.Context, Manifest.Permission.Camera);

            if (permissionCheck == Android.Content.PM.Permission.Granted)
            {
                var intent = new Intent(MediaStore.ActionImageCapture);
                imageFile = new File(imageDirectory, $"JensCafePhoto_{Guid.NewGuid()}.jpg");
                intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));
                StartActivityForResult(intent, requestCode: 0);
            }
            else
            {
                SetCameraPermissionAsync();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public Task SetCameraPermissionAsync()
        {
            return Task.Run(() =>
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.Camera }, 101);
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.WriteExternalStorage }, 1);
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.ReadExternalStorage }, 1);
            });
        }
    }
}