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
    public partial class TheaterPage : ContentPage
    {
        public TheaterPage()
        {
            InitializeComponent();
        }

        private void EntSearchTheater_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CvTheaters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}