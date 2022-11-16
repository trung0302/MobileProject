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
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();
            LblUserName.Text = Preferences.Get("userName", string.Empty);
        }

        private void TapGestureRecognizer_Tapped_About(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }

        private void TapGestureRecognizer_Tapped_Contact(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContactPage());

        }

        private void TapGestureRecognizer_Tapped_LogOut(object sender, EventArgs e)
        {
            Preferences.Set("accessToken", string.Empty);
            Preferences.Set("tokenExpirationTime", 0);
            Application.Current.MainPage = new NavigationPage(new SignUpPage());
        }
    }
}