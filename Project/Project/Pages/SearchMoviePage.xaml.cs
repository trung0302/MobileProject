using Project.Models;
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
    public partial class SearchMoviePage : ContentPage
    {
        public SearchMoviePage()
        {
            InitializeComponent();
        }

        private async void EntSearchMovie_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue.Trim()) && string.IsNullOrWhiteSpace(e.NewTextValue.Trim()))
            {
                CvMovies.ItemsSource = "";
            } 
            else
            {
                var moviesList = await ApiService.FindMovies(e.NewTextValue.ToLower());
                CvMovies.ItemsSource = moviesList;
            }
        }

        private void CvMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as FindMovie;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new MovieDetailPage(currentSelection.Id));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}