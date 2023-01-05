using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TheaterPage : ContentPage
    {
        public TheaterPage()
        {
            InitializeComponent();

            GetTheaters();
        }

        private async void GetTheaters()
        {
            var theaters = await ApiService.GetTheaters();

            CvTheaters.ItemsSource = theaters;
        }

        private async void EntSearchTheater_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue.Trim()) && string.IsNullOrWhiteSpace(e.NewTextValue.Trim()))
            {
                GetTheaters();
            }
            else
            {
                var theatersList = await ApiService.FindTheaters(e.NewTextValue.ToLower());
                CvTheaters.ItemsSource = theatersList;
            }
        }

        private void CvTheaters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void MyRefreshView_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(500);
            MyRefreshView.IsRefreshing = false;
        }
    }
}