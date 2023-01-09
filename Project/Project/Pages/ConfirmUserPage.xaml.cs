using Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmUserPage : ContentPage
    {
        public ConfirmUserPage()
        {
            InitializeComponent();
        }

        private async void cmdResetPass_Clicked(object sender, EventArgs e)
        {
            var response = await ApiService.ConfirmEmail(EntEmail.Text);
            //var u = user;
            if (response)
            {
                var user = await ApiService.GetUserByEmail(EntEmail.Text);
                await Navigation.PushModalAsync(new VerifyCodePage(user.Email));
            }
            else
            {
                await DisplayAlert("Thông báo", "Email không đúng hoặc không tồn tại! Vui lòng nhập lại email!", "Đồng ý");
            }
        }

        private void ImgBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}