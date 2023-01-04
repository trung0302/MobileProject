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
            if (e.NewTextValue == null)
            {
                return;
            }
            var moviesList = await ApiService.FindMovies(e.NewTextValue.ToLower());
            CvTheaters.ItemsSource = moviesList;
        }

        private void CvTheaters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}