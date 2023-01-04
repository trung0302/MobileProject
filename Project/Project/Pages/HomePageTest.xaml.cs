using Project.Models;
using Project.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project.Services;
using System.Net.Http;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageTest : ContentPage
    {
        //public ObservableCollection<Movie> kinhdiMoviesCollection;
        //public ObservableCollection<Movie> hanhdongMoviesCollection;
        //public ObservableCollection<Movie> tinhcamMoviesCollection;
        //public ObservableCollection<Movie> hoathinhMoviesCollection;
        //public ObservableCollection<Movie> ratingMoviesCollection;
        //public ObservableCollection<Movie> dexuatMoviesCollection;
        public ObservableCollection<Movie> top3MoviesCollection;

        public HomePageTest()
        {
            InitializeComponent();
            top3MoviesCollection = new ObservableCollection<Movie>();
           
            GetTop3();
            GetRatingFilm();
            GetAdviceFilm();
            GetGenre();
        }

        //private void GetMovies()
        //{
        //    //pageNumber++;
        //    //var movies = await ApiService.GetAllMovies(pageNumber, 5);
        //    //foreach (var movie in movies)
        //    //{
        //    //    MoviesCollection.Add(movie);
        //    //}
        //    MoviesCollection.Add(new Movie { Id = 1, Name = "Doctor Strange", Duration = "15", Language = "English", Rating = 4.5, Genre = "123", ImageUrl = "filmdemo.png" });
        //    MoviesCollection.Add(new Movie { Id = 1, Name = "Doctor Strange", Duration = "15", Language = "English", Rating = 4.5, Genre = "123", ImageUrl = "filmdemo.png" });
        //    MoviesCollection.Add(new Movie { Id = 1, Name = "Doctor Strange", Duration = "15", Language = "English", Rating = 4.5, Genre = "123", ImageUrl = "filmdemo.png" });
        //    MoviesCollection.Add(new Movie { Id = 1, Name = "Doctor Strange", Duration = "15", Language = "English", Rating = 4.5, Genre = "123", ImageUrl = "filmdemo.png" });
        //    MoviesCollection.Add(new Movie { Id = 1, Name = "Doctor Strange", Duration = "15", Language = "English", Rating = 4.5, Genre = "123", ImageUrl = "filmdemo.png" });
        //    CvMovies.ItemsSource = MoviesCollection;
        //    CvMoviesDexuat.ItemsSource = MoviesCollection;
        //    CvMoviesHanhDong.ItemsSource = MoviesCollection;
        //    CvMoviesKinhDi.ItemsSource = MoviesCollection;
        //    CvMoviesTinhCam.ItemsSource = MoviesCollection;
        //    CvMoviesFilm.ItemsSource = MoviesCollection;
        //    Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
        //    {
        //        //CvMoviesFilm.Position = (CvMoviesFilm.Position + 1) % indicatorView.Count;
        //        if (CvMoviesFilm.Position == MoviesCollection.ToList().Count() - 1)
        //        {
        //            CvMoviesFilm.Position = 0;
        //        } 
        //        else
        //        {
        //            CvMoviesFilm.Position = (CvMoviesFilm.Position + 1);

        //        }
        //        return true;
        //    }));
        //}
        private async void GetGenre()
        {
            var kinhdiMovies = await ApiService.GetGenre("kinhdi");
            var hanhdongMovies = await ApiService.GetGenre("hanhdong");
            var tinhcamMovies = await ApiService.GetGenre("tinhcam");
            var hoathinhMovies = await ApiService.GetGenre("hoathinh");

            CvKinhDiMovies.ItemsSource = kinhdiMovies;
            CvHanhDongMovies.ItemsSource = hanhdongMovies;
            CvTinhCamMovies.ItemsSource = tinhcamMovies;
            CvHoatHinhMovies.ItemsSource = hoathinhMovies;

        }

        private async void GetTop3()
        {
            var top3Movies = await ApiService.GetTop3();

            foreach (var movie in top3Movies)
            {
                top3MoviesCollection.Add(movie);
            }
            CvTop3Movies.ItemsSource = top3MoviesCollection;
            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            {
                //CvMoviesFilm.Position = (CvMoviesFilm.Position + 1) % indicatorView.Count;
                if (CvTop3Movies.Position == top3MoviesCollection.ToList().Count() - 1)
                {
                    CvTop3Movies.Position = 0;
                }
                else
                {
                    CvTop3Movies.Position = (CvTop3Movies.Position + 1);

                }
                return true;
            }));
        }

        private async void GetAdviceFilm()
        {
            var Movies = await ApiService.GetAdviceFilm();
            CvDeXuatMovies.ItemsSource = Movies;
        }

        private async void GetRatingFilm()
        {
            var Movies = await ApiService.GetRatingFilm();
            CvRatingMovies.ItemsSource = Movies;
        }

        private void CvMovies_RemainingItemsThresholdReached(object sender, EventArgs e)
        {
            GetGenre();
        }

        private void CvMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as Movie;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new MovieDetailPage(currentSelection.Id));
            ((CollectionView)sender).SelectedItem = null;
        }

        private void ImgDetail_Tapped(object sender, EventArgs e)
        {
            Image tab = (Image)sender;
            Movie movie = tab.BindingContext as Movie;
            Navigation.PushModalAsync(new MovieDetailPage(movie.Id));
        }

        private void ToolbarSearch_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SearchMoviePage());
        }

        private void CvHanhDongMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as Movie;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new MovieDetailPage(currentSelection.Id));
            ((CollectionView)sender).SelectedItem = null;
        }

        private void CvKinhDiMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as Movie;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new MovieDetailPage(currentSelection.Id));
            ((CollectionView)sender).SelectedItem = null;
        }

        private void CvTinhCamMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as Movie;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new MovieDetailPage(currentSelection.Id));
            ((CollectionView)sender).SelectedItem = null;
        }

        private void CvHoatHinhMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as Movie;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new MovieDetailPage(currentSelection.Id));
            ((CollectionView)sender).SelectedItem = null;
        }
        private void CvRatingMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as Movie;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new MovieDetailPage(currentSelection.Id));
            ((CollectionView)sender).SelectedItem = null;
        }

        private void cmdNavigate_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button; 
            var model = button.BindingContext as Movie;

            Navigation.PushModalAsync(new MovieDetailPage(model.Id));
        }

        //    private void TapLogout_Tapped(object sender, EventArgs e)
        //    {
        //        Preferences.Set("accessToken", string.Empty);
        //        Preferences.Set("tokenExpirationTime", 0);
        //        Application.Current.MainPage = new NavigationPage(new SignUpPage());
        //    }
    }
}