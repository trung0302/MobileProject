using Project.Models;
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
    public partial class VerifyCodePage : ContentPage
    {
        private string _email;
        public VerifyCodePage(string email)
        {
            _email = email;
            InitializeComponent();
        }

        private void ImgBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void cmdResetPass_Clicked(object sender, EventArgs e)
        {
            var code = EntCode.Text;
            var response = await ApiService.GetCodeByEmail(_email, code);

            if (response)
            {
                await Navigation.PushModalAsync(new ForgotPasswordPage(_email, code));
            }
            else
            {
                await DisplayAlert("Thông báo", "Mã xác nhận không hợp lệ! Vui lòng nhập lại!", "Đồng ý");
            }
        }
    }
}