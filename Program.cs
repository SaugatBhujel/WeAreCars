using System;
using System.Windows.Forms;

namespace WeAreCars
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var splashScreen = new SplashScreen();
            // Set the correct path to the GIF file
            string gifPath = "Resources/car-logo.gif";
            splashScreen.SetLogoGif(gifPath);
            
            Application.Run(splashScreen);
        }
    }
} 