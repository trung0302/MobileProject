using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        private string userId;
        public ObservableCollection<Order> MoviesCollection;
        public OrderPage()
        {
            InitializeComponent();
            MoviesCollection = new ObservableCollection<Order>();

            GetTicket();
        }

        public async void GetTicket()
        {
            //MoviesCollection.Add(new Movie { Id = "1", Name = "Doctor Strange", Duration = "15", Language = "English", Rating = 4.5, Genre = "123", ImageUrl = "filmdemo.png", FullImageUrl = "filmdemo.png" });
            //MoviesCollection.Add(new Movie { Id = "1", Name = "Doctor Strange", Duration = "15", Language = "English", Rating = 4.5, Genre = "123", ImageUrl = "filmdemo.png", FullImageUrl = "filmdemo.png" });
            //MoviesCollection.Add(new Movie { Id = "1", Name = "Doctor Strange", Duration = "15", Language = "English", Rating = 4.5, Genre = "123", ImageUrl = "filmdemo.png", FullImageUrl = "filmdemo.png" });
            //MoviesCollection.Add(new Movie { Id = "1", Name = "Doctor Strange", Duration = "15", Language = "English", Rating = 4.5, Genre = "123", ImageUrl = "filmdemo.png", FullImageUrl = "filmdemo.png" });
            //MoviesCollection.Add(new Movie { Id = "1", Name = "Doctor Strange", Duration = "15", Language = "English", Rating = 4.5, Genre = "123", ImageUrl = "filmdemo.png", FullImageUrl = "filmdemo.png" });
            userId = Preferences.Get("userId", string.Empty);
            var movies = await ApiService.GetTickets(userId);

            foreach (var movie in movies)
            {
                MoviesCollection.Add(movie);
            }
            //CvTickets.ItemsSource = MoviesCollection;
            CvTickets.ItemsSource = movies;
        }
        private void ToolbarSearch_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchMoviePage());
        }

        private async void MyRefreshView_Refreshing(object sender, EventArgs e)
        {
            GetTicket();
            await Task.Delay(500);
            MyRefreshView.IsRefreshing = false;
        }
    }
}