using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventsApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingUpPage : ContentPage {
        public SingUpPage() {
            InitializeComponent();
        }

        private void SingUpButton_Clicked(object sender, EventArgs e) {
            NavigationPage page = new NavigationPage(new EventsPage()) {
                HeightRequest = 500,
                BarTextColor = Color.FromHex("#ffffff"),
                BarBackgroundColor = Color.FromHex("#4a2ca8"),
                BackgroundColor = Color.FromHex("#4a2ca8")

            };
            App.Current.MainPage = page;
        }
    }
}