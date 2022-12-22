using Project.Models;
using System;
using Project.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
        private int ticketPrice;
        private int movieId;
        //public ReservationPage(MovieDetail movie)
        //{
        //    InitializeComponent();
        //    LblMovieName.Text = movie.Name;
        //    LblGenre.Text = movie.Genre;
        //    LblRating.Text = movie.Rating.ToString();
        //    LblLanguage.Text = movie.Language;
        //    LblDuration.Text = movie.Duration;
        //    ImgMovie.Source = movie.FullImageUrl;
        //    SpanPrice.Text = SpanTotalPrice.Text = movie.TicketPrice.ToString();
        //    ticketPrice = movie.TicketPrice;
        //    movieId = movie.Id;
        //}

        public ReservationPage(MovieDetail movie)
        {
            InitializeComponent();
            LblMovieName.Text = "Doctor Strange";
            LblGenre.Text = "123";
            LblRating.Text = "4.5";
            LblLanguage.Text = "English";
            LblDuration.Text = "15";
            ImgMovie.Source = "posterdemosmall.jpg";
            SpanPrice.Text = SpanTotalPrice.Text = "$" + "100000";
            ticketPrice = 100000;
            movieId = 1;
        }

        private void PickerQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            var qty = PickerQty.Items[PickerQty.SelectedIndex];
            SpanQty.Text = qty;
            int totalPrice = Convert.ToInt16(SpanQty.Text) * ticketPrice;
            SpanTotalPrice.Text = totalPrice.ToString();
        }

        private async void ImgReserve_Tapped(object sender, EventArgs e)
        {
            var reservation = new Reservation()
            {
                UserId = Preferences.Get("userId", 0),
                MovieId = movieId,
                Phone = EntPhone.Text,
                Qty = Convert.ToInt32(SpanQty.Text),
                Price = Convert.ToInt32(SpanTotalPrice.Text)
            };

            var response = await ApiService.ReserveMovieTicket(reservation);
            if (response)
            {
                await DisplayAlert("", "Your ticket has been reserved", "Alright");
            }
            else
            {
                await DisplayAlert("Oops", "Something went wrong", "Cancel");
            }
        }

        private void ImgBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void cmdPayment_Clicked(object sender, EventArgs e)
        {

        }
    }
}