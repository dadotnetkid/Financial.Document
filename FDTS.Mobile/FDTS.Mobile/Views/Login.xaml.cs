using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDTS.Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace FDTS.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin(object sender, EventArgs e)
        {
         
            var scanPage = new ZXingScannerPage(BarcodeService.MobileBarcodeScanningOptions);
            scanPage.AutoFocus();
            scanPage.OnScanResult += (result) =>
            {
                // Stop scanning
                scanPage.IsScanning = false;
                scanPage.AutoFocus(0, 500);

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                    //DisplayAlert("Scanned Barcode", result.Text, "OK");
                    HttpService httpService = new HttpService($"http://tracker.imnotonline.ga/login-barcode/{result.Text}");


                    try
                    {
                        var res = await httpService.Login();
                    await DisplayAlert("Scanned Barcode", res.Users.FullName, "OK");
                        Application.Current.MainPage = new MainPage(res);
                    }
                    catch (Exception exception)
                    {
                        await DisplayAlert("Scanned Barcode", "Invalid Credential Try Again", "OK");
                    }


                });
            };
            await Navigation.PushModalAsync(scanPage);
        }
    }
}