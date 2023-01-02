using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Project
{
    public static class AppSettings
    {
        public static string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.6:9372/" : "https://localhost:44312/";
        //public static string ApiUrl = "http://192.168.1.6:9372/";
    }
}
