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
            App.Current.MainPage = new NavigationPage(new EventsPage());
        }
    }
}