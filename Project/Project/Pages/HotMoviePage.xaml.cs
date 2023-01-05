using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
        public HotMoviePage()
        {
            InitializeComponent();

            GetMovies();
        }

        private async void GetMovies()
        {
            var movies = await ApiService.GetHotMovie();
            CvMovieDetail.ItemsSource = movies;
        }

       

        private void ImgDetail_Tapped(object sender, EventArgs e)
        {
            Image tab = (Image)sender;
            Movie movie = tab.BindingContext as Movie;
            Navigation.PushModalAsync(new MovieDetailPage(movie.Id));
        }

        private void ToolbarSearch_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchMoviePage());
        }
    }
    public class SubStringMonthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = (string)value;
            return s.Substring(3, 2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class SubStringDayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = (string)value;
            return s.Substring(0, 2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}