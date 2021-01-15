using EventsApp.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventsAppRemastered.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsPage : ContentPage {
        public EventsPage() {
            InitializeComponent();

            // remove nav bar
            NavigationPage.SetHasNavigationBar(this, false);

            // set events collection
            Events = new ObservableCollection<Event>();

            // add testing event
            Event evn = new Event() {
                Name = "Name",
                TimeRemaining = "TimeRemaining",
                Date = "Date",
                TimeFromTo = "TimeFromTo",
                Place = "Place",
                Note = "Note"
            };
            Events.Add(evn);

            Event lele = new Event() {
                Name = "Name 2",
                TimeRemaining = "TimeRemaining 2",
                Date = "Date 2",
                TimeFromTo = "TimeFromTo 2",
                Place = "Place 2",
                Note = "Note 2"
            };
            Events.Add(lele);

            // bind to listview
            EventsListView.ItemsSource = Events;
        }

        public ObservableCollection<Event> Events { get; }

        private void AddEventButton_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new AddEventPage());
        }
    }
}