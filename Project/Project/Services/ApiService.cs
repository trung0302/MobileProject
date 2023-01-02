using Newtonsoft.Json;
using Project.Models;
using Project.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnixTimeStamp;
using Xamarin.Essentials;

namespace Project.Services
{
    public static class ApiService
    {
        public static async Task<bool> RegisterUser(string name, string email, string password)
        {
            var register = new Register()
            {
                Name = name,
                Email = email,
                Password = password
            };
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            
            //var httpClient = new HttpClient(new System.Net.Http.HttpClientHandler());
            var json = JsonConvert.SerializeObject(register);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/User/Register", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<bool> Login(string email, string password)
        {
            var login = new Login()
            {
                Email = email,
                Password = password
            };
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            //var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/User/Login", content);
            if (!response.IsSuccessStatusCode) return false;
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UserResponse>(jsonResult);
            Preferences.Set("token", result.token);
            Preferences.Set("userId", result.id);
            Preferences.Set("userName", result.name);
            //Preferences.Set($"tokenExpirationTime", result.expiration_Time);
            Preferences.Set("currentTime", UnixTime.GetCurrentTime());
            return true;
        }

        public static async Task<List<Movie>> GetAllMovies(int pageNumber, int pageSize)
        {
            //await TokenValidator.CheckTokenValidity();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + String.Format("api/Movie/AllMovies?pageNumber={0}&pageSize={1}", pageNumber, pageSize));
            return JsonConvert.DeserializeObject<List<Movie>>(response);
        }

        public static async Task<List<Movie>> GetGenre(string genre)
        {
            //await TokenValidator.CheckTokenValidity();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + String.Format("api/Movie/MovieGenre?genre=" + genre));
            return JsonConvert.DeserializeObject<List<Movie>>(response);
        }

        public static async Task<List<Movie>> GetAdviceFilm()
        {
            //await TokenValidator.CheckTokenValidity();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + String.Format("api/Movie/MovieAdvice"));
            return JsonConvert.DeserializeObject<List<Movie>>(response);
        }

        public static async Task<List<Movie>> GetTop3()
        {
            //await TokenValidator.CheckTokenValidity();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + String.Format("api/Movie/GetThreeFilms"));
            return JsonConvert.DeserializeObject<List<Movie>>(response);
        }

        public static async Task<MovieDetail> GetMovieDetail(string movieId)
        {
            //await TokenValidator.CheckTokenValidity();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Movie/MovieDetail/" + movieId);
            return JsonConvert.DeserializeObject<MovieDetail>(response);
        }

        public static async Task<List<FindMovie>> FindMovies(string movieName)
        {
            //await TokenValidator.CheckTokenValidity();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Movie/FindMovies?movieName=" + movieName);
            return JsonConvert.DeserializeObject<List<FindMovie>>(response);
        }


        public static async Task<bool> ReserveMovieTicket(Reservation reservation)
        {
            //await TokenValidator.CheckTokenValidity();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);

            var json = JsonConvert.SerializeObject(reservation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/Reservation/Post", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<List<Order>> GetTickets(string userId)
        {
            //await TokenValidator.CheckTokenValidity();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Reservation/GetTickets?userId=" + userId);
            return JsonConvert.DeserializeObject<List<Order>>(response);
        }
    }

    public static class TokenValidator
    {
        public static async Task CheckTokenValidity()
        {
            var expirationTime = Preferences.Get("tokenExpirationTime", 0);
            Preferences.Set("currentTime", UnixTime.GetCurrentTime());
            var currentTime = Preferences.Get("currentTime", 0);
            if (expirationTime < currentTime)
            {
                var email = Preferences.Get("email", string.Empty);
                var password = Preferences.Get("password", string.Empty);
                await ApiService.Login(email, password);
            }
        }
    }
}
