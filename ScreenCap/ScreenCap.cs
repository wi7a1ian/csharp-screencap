using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FilthyNotebook.Utils
{
    class ScreenCap
    {
        public static void Capture(string filename, int x, int y, int width, int height, ImageFormat imageFormat, int quality)
        {
            Rectangle bounds = new Rectangle(x, y, width, height);

            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(
                    new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size
                );
                //
                if (imageFormat == ImageFormat.Jpeg)
                {
                    EncoderParameters encoderParams = new EncoderParameters(1);
                    encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                    bitmap.Save(filename, GetEncoderInfo("image/jpeg"), encoderParams);
                }
                else
                {
                    bitmap.Save(filename, imageFormat);
                }
            }
        }
        public static void CaptureJPG(string jpgFileName, int quality)
        {
            Capture(jpgFileName,
                Convert.ToInt32(SystemInformation.VirtualScreen.X),
                Convert.ToInt32(SystemInformation.VirtualScreen.Y), 
                Convert.ToInt32(SystemInformation.VirtualScreen.Width),
                Convert.ToInt32(SystemInformation.VirtualScreen.Height),
                ImageFormat.Jpeg, quality);
        }

        public static void CapturePNG(string pngFileName)
        {
            Capture(pngFileName,
                Convert.ToInt32(SystemInformation.VirtualScreen.X),
                Convert.ToInt32(SystemInformation.VirtualScreen.Y), 
                Convert.ToInt32(SystemInformation.VirtualScreen.Width), 
                Convert.ToInt32(SystemInformation.VirtualScreen.Height),
                ImageFormat.Png, 100);
        }

        #region private methods
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        #endregion private methods
    }
}
