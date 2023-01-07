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
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

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
            LblTicketQty.Text = movie.SoVe.ToString();
            ImgMovie.Source = movie.ImageUrl;
            //SpanPrice.Text = SpanTotalPrice.Text = String.Format("{0:n0}", movie.TicketPrice); 
            SpanTotalPrice.Text = String.Format("{0:n0}", movie.TicketPrice);
            ticketPrice = movie.TicketPrice;
            movieId = movie.Id;
            GetTicketQty();
        }

        public async void GetTicketQty()
        {
            var movie = await ApiService.GetMovieDetail(movieId);

            LblTicketQty.Text = movie.SoVe.ToString();
        }

        private void PickerQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            var qty = PickerQty.Items[PickerQty.SelectedIndex];
            //SpanQty.Text = qty;
            //double totalPrice = Convert.ToDouble(SpanQty.Text) * ticketPrice;
            double totalPrice = Convert.ToInt32(qty) * ticketPrice;
            SpanTotalPrice.Text = String.Format("{0:n0}", totalPrice);
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
            //var a = Convert.ToInt32(SpanQty.Text);
            var a = Convert.ToInt32(PickerQty.Items[PickerQty.SelectedIndex]);
            var b = a;
            var reservation = new Reservation()
            {
                Quantity = a,
                Price = Convert.ToDouble(SpanTotalPrice.Text),
                Phone = EntPhone.Text,
                PhuongThuc = SpanPayment,
                Theater = SpanTheater,
                MovieId = movieId,
                UserId = Preferences.Get("userId", string.Empty),
            };

            var movieById = await ApiService.GetMovieDetail(movieId);
            if (movieById != null)
            {
                if (movieById.SoVe > 0)
                {
                    if (movieById.SoVe >= reservation.Quantity)
                    {
                        var response = await ApiService.ReserveMovieTicket(reservation);
                        if (response)
                        {
                            await DisplayAlert("Thông báo", "Bạn đã đặt vé thành công!", "Đồng ý");
                            GetTicketQty();
                        }
                        else
                        {
                            await DisplayAlert("Thông báo", "Vui lòng điền đẩy đủ thông tin trước khi thanh toán!", "Hủy");
                        }
                    }
                    else
                    {
                            await DisplayAlert("Thông báo", "Số vé còn lại của phim không đủ! Vui lòng đặt số vé ít hơn!", "Hủy");
                    }
                }
                else
                {
                    await DisplayAlert("Thông báo", "Phim đã bán hết vé! Quý khách vui lòng quay lại vào dịp khác!", "Hủy");
                }
            }
            else
            {
                await DisplayAlert("Thông báo", "Có lỗi BE!", "Hủy");
            }
        }

        private async void MyRefreshView_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(500);
            MyRefreshView.IsRefreshing = false;
        }
    }
}