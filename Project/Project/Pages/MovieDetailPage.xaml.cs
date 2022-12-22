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
        public MovieDetailPage(int movieId)
        {
            InitializeComponent();
            GetMovieDetail(movieId);
        }

        //private async void GetMovieDetail(int movieId)
        //{
        //    movie = await ApiService.GetMovieDetail(movieId);
        //    LblMovieName.Text = movie.Name;
        //    LblGenre.Text = movie.Genre;
        //    LblRating.Text = movie.Rating.ToString();
        //    LblLanguage.Text = movie.Language;
        //    LblDuration.Text = movie.Duration;
        //    LblPlayingDate.Text = movie.PlayingDate;
        //    LblPlayingTime.Text = movie.PlayingTime;
        //    LblTicketPrice.Text = "$" + movie.TicketPrice;
        //    LblMovieDescription.Text = movie.Description;
        //    ImgMovie.Source = movie.FullImageUrl;
        //    ImgMovieCover.Source = movie.FullImageUrl;

        //}

        private  void GetMovieDetail(int movieId)
        {
            //movie = await ApiService.GetMovieDetail(movieId);
            LblMovieName.Text = "Doctor Strange";
            LblGenre.Text = "123";
            LblRating.Text = "4.5";
            LblLanguage.Text = "English";
            LblDuration.Text = "15";
            LblPlayingDate.Text = "20-11-2022";
            LblPlayingTime.Text = "22:00";
            LblTicketPrice.Text = "100000" + " VNĐ";
            LblMovieDescription.Text = "Đang tất bật chuẩn bị cho đám cưới triệu đô cùng chàng Jack điển trai, Đại mỹ nhân showbiz Ms. Q / Hoàng Quyên (Ninh Dương Lan Ngọc) bất ngờ gặp lại Quỳnh Yên (Kaity Nguyễn), một người em gái đã mất liên lạc từ lâu. Ngay sau đó, các rắc rối bí ẩn liên tục ập đến, kéo theo hàng loạt bí mật đen tối của cả hai cũng dần bị lột trần. Ai là kẻ đứng sau 'giật dây' mọi chuyện? Ai mới là nạn nhân? P/S: Bất kể cô ta có nói gì cũng nên nhớ: Đừng tin lời cô ta nói!";
            ImgMovie.Source = "filmdemo.png";
            ImgMovieCover.Source = "posterdemosmall.jpg";

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
            Navigation.PushModalAsync(new VideoPlayerPage("https://youtu.be/WsBV9s1SqpM"));
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