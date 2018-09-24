using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilthyNotebook.Utils
{
    class Program
    {
        static void Main(string[] args)
        {
            ScreenCap.CapturePNG("out.png");
            ScreenCap.CaptureJPG("out.jpg", 80);
        }
    }
}
