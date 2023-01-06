using Project.Services;
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

            GetUserName();
        }

        public async void GetUserName()
        {
            var id = Preferences.Get("userId", string.Empty);
            var user = await ApiService.GetUser(id);

            //LblUserName.Text = Preferences.Get("userName", string.Empty);
            LblUserName.Text = user.Name;
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
            //Application.Current.MainPage = new NavigationPage(new LoginPage());
            Application.Current.MainPage = new LoginPage();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingPage());
        }

        private async void myRefreshView_Refreshing(object sender, EventArgs e)
        {
            GetUserName();
            await Task.Delay(500);
            myRefreshView.IsRefreshing = false;
        }

        private void ImgEdit_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UpdateNamePage());
        }

        private void cmdClick_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UpdateNamePage());
        }
    }
}