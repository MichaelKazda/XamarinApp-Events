using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventsApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEventPage : ContentPage {
        public AddEventPage() {
            InitializeComponent();
        }

        private void GetImageButton_Clicked(object sender, EventArgs e) {
            CrossToastPopUp.Current.ShowToastMessage("Image from gallery action");
        }

        private void AddEventButton_Clicked(object sender, EventArgs e) {
            CrossToastPopUp.Current.ShowToastMessage("Event added");
        }
    }
}