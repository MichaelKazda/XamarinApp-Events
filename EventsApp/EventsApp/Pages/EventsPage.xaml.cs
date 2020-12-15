using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsApp.Classes;
using Plugin.Toast;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventsApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsPage : ContentPage {
        public EventsPage() {
            InitializeComponent();

            // remove nav bar
            NavigationPage.SetHasNavigationBar(this, false);

            ObservableCollection<Event> events = new ObservableCollection<Event>();

            Event evn = new Event() {
                Name = "neco"       
            };
            events.Add(evn);

            Event lelle = new Event()
            {
                Name = "diuwhdiuwq"
            };
            events.Add(lelle);

            EventsListView.ItemsSource = events;

        }

        private void AddEventButton_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new AddEventPage());
        }
    }
}