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

        private void GetMovies()
        {
            //pageNumber++;
            //var movies = await ApiService.GetAllMovies(pageNumber, 5);
            //foreach (var movie in movies)
            //{
            //    MoviesCollection.Add(movie);
            //}

            MoviesCollection.Add(new Movie { Id = 1, Name = "Doctor Strange", Duration = "15", Language = "English", Rating = 4.5, Genre = "123", ImageUrl = "filmdemo.png" });
            MoviesCollection.Add(new Movie { Id = 1, Name = "Doctor Strange", Duration = "15", Language = "English", Rating = 4.5, Genre = "123", ImageUrl = "filmdemo.png" });
            MoviesCollection.Add(new Movie { Id = 1, Name = "Doctor Strange", Duration = "15", Language = "English", Rating = 4.5, Genre = "123", ImageUrl = "filmdemo.png" });
            MoviesCollection.Add(new Movie { Id = 1, Name = "Doctor Strange", Duration = "15", Language = "English", Rating = 4.5, Genre = "123", ImageUrl = "filmdemo.png" });
            MoviesCollection.Add(new Movie { Id = 1, Name = "Doctor Strange", Duration = "15", Language = "English", Rating = 4.5, Genre = "123", ImageUrl = "filmdemo.png" });
            CvMovieDetail.ItemsSource = MoviesCollection;
        }

        private void ImgDetail_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MovieDetailPage(1));
        }

        private void ToolbarSearch_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchMoviePage());
        }
    }
}