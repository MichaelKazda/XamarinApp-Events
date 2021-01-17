using EventsApp.Database;
using EventsAppRemastered.Database;
using EventsAppRemastered.Popups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventsAppRemastered.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsPage : ContentPage {

        public static EventDB EventDatabase;
        public static List<Event> eventCache;

        public EventsPage(EventDB _EventDatabase) {
            InitializeComponent();
            EventDatabase = _EventDatabase;

            //EventDatabase.DeleteEventsAsync();

            // remove nav bar
            NavigationPage.SetHasNavigationBar(this, false);

            // run events update watcher
            Task.Run(() => WatchEvents());
            
        }

        private void AddEventButton_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new AddEventPage(EventDatabase));
        }

        private void DeleteEventButton_Clicked(object sender, EventArgs e) {
            var SenderButton = (Button)sender;
            string ID = SenderButton.ClassId;
            DeleteEvent(ID);
        }

        public void WatchEvents() {
            while (true) {
                Thread.Sleep(500);
                Dispatcher.BeginInvokeOnMainThread(() => LoadEvents());
            }
        }

        public async void SaveEventToDatabase(Event evn) {
            await EventDatabase.SaveEventAsync(evn);
        }

        public async void LoadEvents() {
            var eventCache = await EventDatabase.GetEventsAsync();
            foreach (Event evn in eventCache) {
                TimeSpan span = evn.EventStartDate.Subtract(DateTime.Now);
               
                if (span.Seconds < 0) {
                    if (evn.YearlyRepeat)
                        CreateNewEvent(evn);

                    EventDatabase.DeleteEventAsync(evn);

                } else {
                    evn.TimeToStart = $"{span.Days} Days {span.Hours} Hours {span.Minutes} Minutes {span.Seconds} Seconds";
                }
            }
            EventsListView.ItemsSource = eventCache;
        }

        public void CreateNewEvent(Event evn) {
            Event newEvent = evn;
            newEvent.EventStartDate.AddYears(1);
            newEvent.Date.AddYears(1);
            newEvent.YearlyCounter = $"{(int.Parse(newEvent.YearlyCounter) + 1)}";

            SaveEventToDatabase(newEvent);
        }

        public void DeleteEvents() {
            EventDatabase.DeleteEventsAsync();
        }

        public void DeleteEvent(string ID) {
            int evnID = int.Parse(ID);
            EventDatabase.DeleteEventByID(evnID);
            Toaster.Toast($"Event deleted");
        }

    }
}