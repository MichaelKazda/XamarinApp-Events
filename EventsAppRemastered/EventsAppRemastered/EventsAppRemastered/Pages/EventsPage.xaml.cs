using EventsApp.Database;
using EventsAppRemastered.Database;
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

        public static EventDB EventDatabase;
        public static ObservableCollection<Event> EventsCollection { get; set; }

        public EventsPage(EventDB _EventDatabase) {
            InitializeComponent();
            EventDatabase = _EventDatabase;

            // remove nav bar
            NavigationPage.SetHasNavigationBar(this, false);

            EventDatabase.DeleteEventsAsync();

            int x = 1;
            Event evn = new Event() {
                Name = $"Name {x}",
                TimeRemaining = $"TimeRemaining {x}",
                Date = $"Date {x}",
                TimeFromTo = $"TimeFromTo {x}",
                Place = $"Place {x}",
                Note = $"Note {x}"
            };

            SaveEventToDatabase(evn);
        }

        public ObservableCollection<Event> Events { get; }

        private void AddEventButton_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new AddEventPage());
        }

        public async void SaveEventToDatabase(Event evn) {
            await EventDatabase.SaveEventAsync(evn);

            // test 
            LoadEvents();
        }

        public async void LoadEvents() {
            var result = await EventDatabase.GetEventsAsync();
            EventsListView.ItemsSource = result;
        }

        public void DeleteEvents() {
            EventDatabase.DeleteEventsAsync();
        }
    }
}