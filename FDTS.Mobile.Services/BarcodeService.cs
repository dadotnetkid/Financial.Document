using System;
using System.Collections.Generic;
using System.Text;
using ZXing.Mobile;

namespace FDTS.Mobile.Services
{
    public static class BarcodeService
    {

        public static MobileBarcodeScanningOptions MobileBarcodeScanningOptions  {
         get
            {

                var options = new ZXing.Mobile.MobileBarcodeScanningOptions();

                options.PossibleFormats = new List<ZXing.BarcodeFormat>() {
                    ZXing.BarcodeFormat.CODE_128,
                    ZXing.BarcodeFormat.CODE_93,
                    ZXing.BarcodeFormat.CODE_39,
                    ZXing.BarcodeFormat.QR_CODE,
                    ZXing.BarcodeFormat.All_1D,
                    ZXing.BarcodeFormat.AZTEC,
                    ZXing.BarcodeFormat.CODABAR,
                    ZXing.BarcodeFormat.DATA_MATRIX,
                    ZXing.BarcodeFormat.EAN_13,
                    ZXing.BarcodeFormat.EAN_8,
                    ZXing.BarcodeFormat.IMB,
                    ZXing.BarcodeFormat.ITF,
                    ZXing.BarcodeFormat.MAXICODE,
                    ZXing.BarcodeFormat.MSI,
                    ZXing.BarcodeFormat.PDF_417,
                    ZXing.BarcodeFormat.PLESSEY,
                    ZXing.BarcodeFormat.RSS_14,
                    ZXing.BarcodeFormat.RSS_EXPANDED,
                    ZXing.BarcodeFormat.UPC_A,
                    ZXing.BarcodeFormat.UPC_E,
                    ZXing.BarcodeFormat.UPC_EAN_EXTENSION,

                };
                return options;
            }
        }


}
}

