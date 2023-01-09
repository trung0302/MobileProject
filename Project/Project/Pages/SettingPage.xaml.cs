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
        private string username;
        public SettingPage()
        {
            InitializeComponent();
            //EntName.Text = Preferences.Get("userName", string.Empty);
            username = Preferences.Get("userName", string.Empty);
            EntCurrentPassword.Text = "";
            EntNewPassword.Text = "";
        }

        private async void cmdUpdate_Clicked(object sender, EventArgs e)
        {
            var currentPass = Preferences.Get("password", string.Empty);
            var pass = BCrypt.Net.BCrypt.HashPassword(EntCurrentPassword.Text);
            var c = pass;
            var d = currentPass;
            if (!string.IsNullOrEmpty(EntCurrentPassword.Text)
                && !string.IsNullOrEmpty(EntNewPassword.Text)
                && !string.IsNullOrWhiteSpace(EntCurrentPassword.Text)
                && !string.IsNullOrWhiteSpace(EntNewPassword.Text)
                && !string.IsNullOrEmpty(EntNewPasswordAgain.Text)
                && !string.IsNullOrWhiteSpace(EntNewPasswordAgain.Text))
            {
                if (EntCurrentPassword.Text != currentPass)
                {
                    await DisplayAlert("Thông báo", "Mật khẩu hiện tại không đúng! Vui lòng nhập lại mật khẩu!", "Đồng ý");
                }
                else
                {
                    if (EntNewPassword.Text != currentPass)
                    {
                        if (EntNewPassword.Text.Length > 5)
                        {
                            if (EntNewPassword.Text.Equals(EntNewPasswordAgain.Text))
                            {
                                var response = await ApiService.UpdateUser(username, EntNewPassword.Text);
                                if (response)
                                {
                                    await DisplayAlert("Thông báo", "Bạn đã cập nhật mật khẩu thành công!", "Đồng ý");
                                }
                                else
                                {
                                    await DisplayAlert("Thông báo", "Có lỗi! Vui lòng thử lại!", "Đồng ý");
                                }
                            }
                            else
                            {
                                await DisplayAlert("Thông báo", "Mật khẩu nhập lại không đúng!", "Đồng ý");
                            }
                        }
                        else
                        {
                            await DisplayAlert("Thông báo", "Mật khẩu phải tối thiểu 6 kí tự!", "Đồng ý");
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