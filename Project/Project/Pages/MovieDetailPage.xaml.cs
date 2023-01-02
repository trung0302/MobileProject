using Project.Models;
using Project.Pages;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailPage : ContentPage
    {
        private MovieDetail movie;
        private string trailorUrl;
        public MovieDetailPage(string movieId)
        {
            InitializeComponent();
            GetMovieDetail(movieId);
        }

        private async void GetMovieDetail(string movieId)
        {
            movie = await ApiService.GetMovieDetail(movieId);
            LblMovieName.Text = movie.Name;
            LblGenre.Text = movie.Genre;
            LblRating.Text = movie.Rating.ToString();
            LblLanguage.Text = movie.Language;
            LblDuration.Text = movie.Duration;
            LblPlayingDate.Text = movie.PlayingDate;
            LblPlayingTime.Text = movie.PlayingTime;
            LblTicketPrice.Text = String.Format("{0:n0}", movie.TicketPrice) + " VNĐ";
            LblMovieDescription.Text = movie.Description;
            ImgMovieCover.Source = movie.FullImageUrl;
            ImgMovie.Source = movie.ImageUrl;
            trailorUrl = movie.TrailorUrl;
        }

        private void ImgBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        //private void TapVideo_Tapped(object sender, EventArgs e)
        //{
        //    Navigation.PushModalAsync(new VideoPlayerPage(movie.TrailorUrl));
        //}

        private void TapVideo_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new VideoPlayerPage(trailorUrl));
        }
        private void ImgBookTicket_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ReservationPage(movie));
        }

        private void cmdBookTicket_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ReservationPage(movie));
        }
    }
}