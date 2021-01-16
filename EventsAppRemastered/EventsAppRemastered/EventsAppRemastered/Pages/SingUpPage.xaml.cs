using EventsAppRemastered.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventsAppRemastered.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingUpPage : ContentPage {

        public static EventDB EventDatabase;

        public SingUpPage(EventDB _EventDatabase) {
            InitializeComponent();
            EventDatabase = _EventDatabase;

        }

        private void SingUpButton_Clicked(object sender, EventArgs e) {
            GoToMainPage();
        }

        private void GoToMainPage() {
            NavigationPage page = new NavigationPage(new EventsPage(EventDatabase)) {
                HeightRequest = 500,
                BarTextColor = Color.FromHex("#ffffff"),
                BarBackgroundColor = Color.FromHex("#4a2ca8"),
                BackgroundColor = Color.FromHex("#4a2ca8")

            };
            App.Current.MainPage = page;
        }

    }
}