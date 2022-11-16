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
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void cmdTest_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("OK", "DOne", "OK");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://learn.microsoft.com/en-us/xamarin/xamarin-forms/");
        }
    }
}