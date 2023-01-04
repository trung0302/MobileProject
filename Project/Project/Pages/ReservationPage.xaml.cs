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
using static Xamarin.Essentials.Permissions;
using System.Diagnostics;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
        private double ticketPrice;
        private string movieId;
        private string SpanPayment;
        private string SpanTheater;
        public ReservationPage(MovieDetail movie)
        {
            InitializeComponent();
            LblMovieName.Text = movie.Name;
            LblGenre.Text = movie.Genre;
            LblRating.Text = movie.Rating.ToString();
            LblLanguage.Text = movie.Language;
            LblDuration.Text = movie.Duration;
            ImgMovie.Source = movie.FullImageUrl;
            SpanPrice.Text = SpanTotalPrice.Text = String.Format("{0:n0}", movie.TicketPrice);
            ticketPrice = movie.TicketPrice;
            movieId = movie.Id;
        }

        private void PickerQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            var qty = PickerQty.Items[PickerQty.SelectedIndex];
            SpanQty.Text = qty;
            double totalPrice = Convert.ToDouble(SpanQty.Text) * ticketPrice;
            SpanTotalPrice.Text = String.Format("{0:n0}", totalPrice);
        }

        private async void ImgReserve_Tapped(object sender, EventArgs e)
        {
            var reservation = new Reservation()
            {
                UserId = Preferences.Get("userId", string.Empty),
                MovieId = movieId,
                Phone = EntPhone.Text,
                Qty = Convert.ToInt32(SpanQty.Text),
                Price = Convert.ToDouble(SpanTotalPrice.Text)
            };

            var response = await ApiService.ReserveMovieTicket(reservation);
            if (response)
            {
                await DisplayAlert("Thông báo", "Bạn đã đặt vé thành công!", "Đồng ý");
            }
            else
            {
                await DisplayAlert("Thông báo", "Có lỗi! Xin vui lòng thử lại!", "Hủy");
            }
        }

        private void ImgBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void PickerPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            var payment = PickerPhuongThuc.Items[PickerPhuongThuc.SelectedIndex];
            SpanPayment = payment.ToString();
        }   
        private void PickerTheater_SelectedIndexChanged(object sender, EventArgs e)
        {
            var theater = PickerTheater.Items[PickerTheater.SelectedIndex];
            SpanTheater = theater.ToString();
        }

        private async void cmdPayment_Clicked(object sender, EventArgs e)
        {
            var a = Convert.ToInt32(SpanQty.Text);
            var b = SpanTheater;
            var reservation = new Reservation()
            {
                Qty = Convert.ToInt32(SpanQty.Text),
                Price = Convert.ToDouble(SpanTotalPrice.Text),
                Phone = EntPhone.Text,
                PhuongThuc = SpanPayment,
                Theater = SpanTheater,
                UserId = Preferences.Get("userId", string.Empty),
                MovieId = movieId,
            };
            
            var response = await ApiService.ReserveMovieTicket(reservation);
            if (response)
            {
                await DisplayAlert("Thông báo", "Bạn đã đặt vé thành công!", "Đồng ý");
            }
            else
            {
                await DisplayAlert("Thông báo", "Có lỗi! Xin vui lòng thử lại!", "Hủy");
            }
        }

    }
}