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
    public partial class HotMoviePage : ContentPage
    {
        public ObservableCollection<Movie> MoviesCollection;
        private int pageNumber = 0;
        public HotMoviePage()
        {
            InitializeComponent();
            MoviesCollection = new ObservableCollection<Movie>();

            GetMovies();

        }

        private async void GetMovies()
        {
            pageNumber++;
            var movies = await ApiService.GetAllMovies(pageNumber, 5);
            foreach (var movie in movies)
            {
                MoviesCollection.Add(movie);
            }
            CvMovieDetail.ItemsSource = MoviesCollection;
        }
    }
}