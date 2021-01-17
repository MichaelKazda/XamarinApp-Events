using EventsAppRemastered.Database;
using EventsAppRemastered.Popups;
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

        // Login sys
        private void SingUpButton_Clicked(object sender, EventArgs e) {
            if(userName.Text != null) {
                App._UserName = userName.Text;
                GoToMainPage();
            } else {
                Toaster.Toast("Please tell us your name.");
            }
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