using AngleSharp.Css;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeExplode.Channels;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        private string _email;
        private string _code;

        public ForgotPasswordPage(string email, string code)
        {
            _email = email;
            _code = code;
            InitializeComponent();
        }

        private async void cmdReset_Clicked(object sender, EventArgs e)
        {
            var user = await ApiService.GetUserByEmail(_email);
            var username = user.Name;

            if (user != null)
            {
                if (!string.IsNullOrEmpty(EntNewPassword.Text)
                && !string.IsNullOrWhiteSpace(EntNewPassword.Text)
                && !string.IsNullOrEmpty(EntNewPasswordAgain.Text)
                && !string.IsNullOrWhiteSpace(EntNewPasswordAgain.Text))
                { 
                    if (EntNewPassword.Text.Length > 5)
                    {
                        if (EntNewPassword.Text.Equals(EntNewPasswordAgain.Text))
                        {
                            var response = await ApiService.UpdateUser(username, EntNewPassword.Text);
                            if (response)
                            {
                                await ApiService.DeleteCode(_code);
                                await DisplayAlert("Thông báo", "Bạn đã cập nhật mật khẩu thành công!", "Đồng ý");
                                await Navigation.PushModalAsync(new LoginPage());
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
                    await DisplayAlert("Thông báo", "Vui lòng nhập đầy đủ thông tin trước khi cập nhật!", "Đồng ý");
                }
            }
        }
    }
}