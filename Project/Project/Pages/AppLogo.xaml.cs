using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLogo : ContentPage
    {
        public AppLogo()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(3), (Func<bool>)(() =>
            {
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

                InitializeComponent();
                Device.SetFlags(new string[] { "MediaElement_Experimental" });
                Device.SetFlags(new string[] { "Brush_Experimental" });

                var accessToken = Preferences.Get("accessToken", string.Empty);
                if (string.IsNullOrEmpty(accessToken))
                {
                   Application.Current.MainPage =  new LoginPage();
                }
                else
                {
                    Application.Current.MainPage = new MainPage();

                }
                return false;
            }));
        }
    }
}