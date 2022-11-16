using Project.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        //private async void ImgSignup_Tapped(object sender, EventArgs e)
        //{
        //    var response = await ApiService.RegisterUser(EntName.Text, EntEmail.Text, EntPassword.Text);
        //    if (response)
        //    {
        //        await DisplayAlert("Chúc mừng", "Bạn đã tạo tài khoản thành công!", "Đồng ý");
        //        await Navigation.PushModalAsync(new LoginPage());
        //    }
        //    else
        //    {
        //        await DisplayAlert("Lỗi", "Vui lòng nhập đầy đủ thông tin!", "Hủy");
        //    }
        //}

        private async void LblLogin_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }

        private async void cmdSignup_Clicked(object sender, EventArgs e)
        {
            var response = await ApiService.RegisterUser(EntName.Text, EntEmail.Text, EntPassword.Text);
            if (response)
            {
                await DisplayAlert("Chúc mừng", "Bạn đã tạo tài khoản thành công!", "Đồng ý");
                await Navigation.PushModalAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Lỗi", "Vui lòng nhập đầy đủ thông tin!", "Hủy");
            }
        }
    }
}