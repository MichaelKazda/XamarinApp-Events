using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventsApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsPage : ContentPage {
        public EventsPage() {
            InitializeComponent();
        }

        private void AddEventButton_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new AddEventPage());
        }
    }
}