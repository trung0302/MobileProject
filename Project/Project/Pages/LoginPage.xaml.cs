﻿using Project.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project.Services;
namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void ImgBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        //private async void ImgLogin_Tapped(object sender, EventArgs e)
        //{
        //    var response = await ApiService.Login(EntEmail.Text, EntPassword.Text);
        //    Preferences.Set("email", EntEmail.Text);
        //    Preferences.Set("password", EntPassword.Text);
        //    if (response)
        //    {
        //        Application.Current.MainPage = new MainPage();
        //    }
        //    else
        //    {
        //        await DisplayAlert("Oops", "Something went wrong", "Cancel");
        //    }
        //}

        private async void cmdSignin_Clicked(object sender, EventArgs e)
        {
            var response = await ApiService.Login(EntEmail.Text, EntPassword.Text);
            Preferences.Set("email", EntEmail.Text);
            Preferences.Set("password", EntPassword.Text);
            if (response)
            {
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                await DisplayAlert("Lỗi", "Tài khoản hoặc mật khẩu không đúng! Vui lòng nhập lại...", "Hủy");
            }
        }
    }
}