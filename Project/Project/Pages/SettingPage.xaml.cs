using Project.Models;
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
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
            EntName.Text = Preferences.Get("userName", string.Empty);
            EntCurrentPassword.Text = "";
            EntNewPassword.Text = "";
        }

        private async void cmdUpdate_Clicked(object sender, EventArgs e)
        {
            var currentPass = Preferences.Get("password", string.Empty);
            var pass = BCrypt.Net.BCrypt.HashPassword(EntCurrentPassword.Text);
            var c = pass;
            var d = currentPass;
            if (!string.IsNullOrEmpty(EntName.Text) 
                && !string.IsNullOrEmpty(EntCurrentPassword.Text)
                && !string.IsNullOrEmpty(EntNewPassword.Text))
            {
                if (EntCurrentPassword.Text != currentPass)
                {
                    await DisplayAlert("Mật khẩu hiện tại không đúng", "Vui lòng nhập lại mật khẩu!", "Đồng ý");
                }
                else
                {
                    if (EntNewPassword.Text != currentPass)
                    {
                        var response = await ApiService.UpdateUser(EntName.Text, EntNewPassword.Text);
                        if (response)
                        {
                            await DisplayAlert("Thông báo", "Bạn đã cập nhật tài khoản thành công!", "Đồng ý");
                        }
                        else
                        {
                            await DisplayAlert("Thông báo", "Có lỗi! Vui lòng thử lại!", "Đồng ý");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Thông báo", "Mật khẩu mới phải khác với mật khẩu hiện tại!", "Đồng ý");
                    }
                }
            }
            else
            {
                await DisplayAlert("Thông báo", "Vui lòng nhập đầy đủ thông tin trước khi cập nhật!", "Đồng ý");
            }
        }
    }
}