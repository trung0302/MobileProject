using Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeExplode.Channels;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateNamePage : ContentPage
    {
        private string password;
        public UpdateNamePage()
        {
            InitializeComponent();
            EntName.Text = Preferences.Get("userName", string.Empty);
            password = Preferences.Get("password", string.Empty);
        }

        private async void cmdUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EntName.Text)
                && !string.IsNullOrWhiteSpace(EntName.Text))
            {
                var response = await ApiService.UpdateUser(EntName.Text, password);
                if (response)
                {
                    await DisplayAlert("Thông báo", "Bạn đã cập nhật tên tài khoản thành công!", "Đồng ý");
                }
                else
                {
                    await DisplayAlert("Thông báo", "Có lỗi! Vui lòng thử lại!", "Đồng ý");
                }
            }
            else
            {
                await DisplayAlert("Thông báo", "Tên tài khoản không được để trống!", "Đồng ý");
            }
        }
    }
}