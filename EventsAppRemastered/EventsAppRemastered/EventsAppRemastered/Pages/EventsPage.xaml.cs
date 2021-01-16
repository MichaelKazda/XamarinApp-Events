using EventsApp.Database;
using EventsAppRemastered.Database;
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

        public EventsPage(EventDB _EventDatabase) {
            InitializeComponent();
            EventDatabase = _EventDatabase;

            // remove nav bar
            NavigationPage.SetHasNavigationBar(this, false);

            // run events update watcher
            Task.Run(() => WatchEvents());
            
        }

        private void AddEventButton_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new AddEventPage(EventDatabase));
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
            var result = await EventDatabase.GetEventsAsync();
            foreach (Event evn in result) {
                TimeSpan span = evn.EventStartDate.Subtract(DateTime.Now);

                if (int.Parse(span.Seconds.ToString()) < -1) {
                    EventDatabase.DeleteEventAsync(evn);
                } else {
                    evn.TimeToStart = $"Days: {span.Days} Hours: {span.Hours} Minutes: {span.Minutes} Seconds: {span.Seconds}";
                }
            }
            EventsListView.ItemsSource = result;
        }

        public void DeleteEvents() {
            EventDatabase.DeleteEventsAsync();
        }
    }
}