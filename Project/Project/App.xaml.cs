using Project.Pages;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

            //InitializeComponent();
            //Device.SetFlags(new string[] { "MediaElement_Experimental" });
            //Device.SetFlags(new string[] { "Brush_Experimental" });

            //var accessToken = Preferences.Get("accessToken", string.Empty);
            //if (string.IsNullOrEmpty(accessToken))
            //{
            //    MainPage = new NavigationPage(new SignUpPage());
            //}
            //else
            //{
            //    MainPage = new MainPage();
            //}
            MainPage = new NavigationPage(new AppLogo());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
