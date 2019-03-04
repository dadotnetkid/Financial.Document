using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDTS.Mobile.Services;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace FDTS.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage(Services.JwtModel res)
        {
            InitializeComponent();
            BindingContext = res;
            this.JwtModel = res;
        }

        public JwtModel JwtModel { get; set; }


        public MainPage()
        {
            InitializeComponent();
        }
        private async void btn_Scan(object sender, EventArgs e)
        {


            var scanPage = new ZXingScannerPage(BarcodeService.MobileBarcodeScanningOptions);
            scanPage.AutoFocus();
            scanPage.OnScanResult += (result) =>
            {
                // Stop scanning
                scanPage.IsScanning = false;
                scanPage.AutoFocus(0, 500);

                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopModalAsync();
    
                   
                });
            };
            await Navigation.PushModalAsync(scanPage);


        }

        private void btn_Receive(object sender, EventArgs e)
        {
            
        }
    }
}
