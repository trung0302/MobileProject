using Project.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            EntName.Text = "";
            EntEmail.Text = "";
            EntPassword.Text = "";
        }

        private async void LblLogin_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }

        private async void cmdSignup_Clicked(object sender, EventArgs e)
        {
            var email = EntEmail.Text;
            var emailPattern = "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";
            if (!string.IsNullOrEmpty(EntEmail.Text)
                && !string.IsNullOrEmpty(EntName.Text)
                && !string.IsNullOrEmpty(EntPassword.Text))
            {
                if (Regex.IsMatch(email, emailPattern))
                {
                    if (EntPassword.Text.Length > 5)
                    {
                        var response = await ApiService.RegisterUser(EntName.Text, EntEmail.Text, EntPassword.Text);
                        if (response)
                        {
                            await DisplayAlert("Chúc mừng", "Bạn đã tạo tài khoản thành công!", "Đồng ý");
                            await Navigation.PushModalAsync(new LoginPage());
                        }
                        else
                        {
                            await DisplayAlert("Lỗi", "Email đã được đăng ký! Vui lòng nhập email khác!", "Hủy");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Lỗi", "Mật khẩu phải tối thiểu 6 kí tự!", "Hủy");
                    }
                }
                else
                {
                    await DisplayAlert("Lỗi", "Email không hợp lệ!", "Hủy");
                }
            }
            else
            {
                await DisplayAlert("Lỗi", "Vui lòng nhập đầy đủ thông tin!", "Hủy");
            }
        }
    }
}