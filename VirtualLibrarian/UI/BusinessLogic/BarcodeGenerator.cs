using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrarian.Data;
using VirtualLibrarian.Helpers;
using ZXing;

namespace VirtualLibrarian.BusinessLogic
{
    public class BarcodeGenerator
    {
        private string barcodeDir;
        private BarcodeWriter barcodeWriter = new BarcodeWriter();

        public BarcodeGenerator (string barcodeDir)
        {
            this.barcodeDir = barcodeDir;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
        }

        public Image GenerateBarcode(int value)
        {
            var filePath = $"{barcodeDir}\\{value}.bmp";

            try
            {
                barcodeWriter.Write(value.ToString()).Save(filePath);
            }
            catch (Exception e)
            {
                LibraryDataIO.Instance.Logger.LogException(e);
            }
            return Image.FromFile(filePath);

        }



    }
}
