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
        public ObservableCollection<Movie> kinhdiMoviesCollection;
        public ObservableCollection<Movie> hanhdongMoviesCollection;
        public ObservableCollection<Movie> tinhcamMoviesCollection;
        public ObservableCollection<Movie> hoathinhMoviesCollection;
        private int pageNumber = 0;
        public HomePageTest()
        {
            InitializeComponent();
            //LblUserName.Text = Preferences.Get("userName", string.Empty);
            kinhdiMoviesCollection = new ObservableCollection<Movie>();
            hanhdongMoviesCollection = new ObservableCollection<Movie>();
            tinhcamMoviesCollection = new ObservableCollection<Movie>();
            hoathinhMoviesCollection = new ObservableCollection<Movie>();
           
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

            foreach (var genre in kinhdiMovies)
            {
                kinhdiMovies.Add(genre);
            }
            CvMovies.ItemsSource = kinhdiMoviesCollection; 
            
            foreach (var genre in hanhdongMovies)
            {
                hanhdongMovies.Add(genre);
            }

            CvMovies.ItemsSource = hanhdongMoviesCollection;

            foreach (var genre in tinhcamMovies)
            {
                tinhcamMovies.Add(genre);
            }

            CvMovies.ItemsSource = tinhcamMoviesCollection;

            foreach (var genre in hoathinhMovies)
            {
                hoathinhMovies.Add(genre);
            }
            CvMovies.ItemsSource = hoathinhMoviesCollection;



        }
        //    private async void TapMenu_Tapped(object sender, EventArgs e)
        //    {
        //        GridOverlay.IsVisible = true;
        //        await SlMenu.TranslateTo(0, 0, 400, Easing.Linear);
        //    }

        //    private void TapCloseMenu_Tapped(object sender, EventArgs e)
        //    {
        //        CloseHamBurgerMenu();
        //    }

        private void CvMovies_RemainingItemsThresholdReached(object sender, EventArgs e)
        {
            GetGenre();
        }

        //private void CvMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var currentSelection = e.CurrentSelection.FirstOrDefault() as Movie;
        //    if (currentSelection == null) return;
        //    Navigation.PushModalAsync(new MovieDetailPage(currentSelection.Id));
        //    ((CollectionView)sender).SelectedItem = null;
        //}
        private void CvMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Navigation.PushModalAsync(new MovieDetailPage(1));
            ((CollectionView)sender).SelectedItem = null;
        }

        private void ImgDetail_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MovieDetailPage(1));
        }

        private void ToolbarSearch_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchMoviePage());
        }

        //-------------------------------------------------

        //private async void cmdChao_Clicked(object sender, EventArgs e)
        //{
        //    HttpClient http = new HttpClient();
        //    var kq = await http.GetStringAsync("http://192.168.1.70/webapidemo/api/GetController/GetTitle");
        //    lbChao.Text = kq.ToString();
        //}

        //    private async void CloseHamBurgerMenu()
        //    {
        //        await SlMenu.TranslateTo(-250, 0, 400, Easing.Linear);
        //        GridOverlay.IsVisible = false;
        //    }

        //    private void TapSearch_Tapped(object sender, EventArgs e)
        //    {
        //        Navigation.PushModalAsync(new SearchMoviePage());
        //    }

        //    private void TapContact_Tapped(object sender, EventArgs e)
        //    {
        //        Navigation.PushModalAsync(new ContactPage());
        //    }

        //    protected override void OnDisappearing()
        //    {
        //        base.OnDisappearing();
        //        CloseHamBurgerMenu();
        //    }

        //    private void TapLogout_Tapped(object sender, EventArgs e)
        //    {
        //        Preferences.Set("accessToken", string.Empty);
        //        Preferences.Set("tokenExpirationTime", 0);
        //        Application.Current.MainPage = new NavigationPage(new SignUpPage());
        //    }
    }
}