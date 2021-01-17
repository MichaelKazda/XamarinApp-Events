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
        public static string showEvents = "All Time";

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
                Dispatcher.BeginInvokeOnMainThread(() => LoadAllEvents());
  
            }
        }

        public async void SaveEventToDatabase(Event evn) {
            await EventDatabase.SaveEventAsync(evn);
        }

        public async void LoadAllEvents() {
            List<Event> newList = new List<Event>();
            if (showEvents == "All Time") {
                newList = await EventDatabase.GetEventsAsync();
            } else {
                eventCache = await EventDatabase.GetEventsAsync();
                DateTime nowPlusSpan = new DateTime();

                if (showEvents == "Next Week") {
                    nowPlusSpan = DateTime.Now.AddDays(7);
                } else if (showEvents == "Next Month") {
                    nowPlusSpan = DateTime.Now.AddMonths(1);
                } else if (showEvents == "Next Year") {
                    nowPlusSpan = DateTime.Now.AddYears(1);
                }
                var nowPlusStamp = nowPlusSpan.ToFileTime();
                foreach (Event evn in eventCache) {
                    var eventStartDateStamp = evn.EventStartDate.ToFileTime();       
                    if (nowPlusStamp - eventStartDateStamp > 0)
                        newList.Add(evn);
                }
            }

            foreach (Event evn in newList) {
                TimeSpan span = evn.EventStartDate.Subtract(DateTime.Now);   
                if (span.Seconds < 0) {
                    if (evn.YearlyRepeat)
                        CreateNewEvent(evn);

                    EventDatabase.DeleteEventAsync(evn);
                } else {
                    evn.TimeToStart = $"{span.Days} Days {span.Hours} Hours {span.Minutes} Minutes {span.Seconds} Seconds";
                }
            }
            EventsListView.ItemsSource = newList;
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

        private void AllTimeBtnClicked(object sender, EventArgs e) {
            showEvents = "All Time";
            AllTimeBtn.BorderColor = Color.FromHex("#2f1f4f");
            NextWeekBtn.BorderColor = Color.FromHex("#4a2ca8");
            NextMonthBtn.BorderColor = Color.FromHex("#4a2ca8");
            NextYearBtn.BorderColor = Color.FromHex("#4a2ca8");

        }

        private void NextWeekBtnClicked(object sender, EventArgs e) {
            showEvents = "Next Week";
            AllTimeBtn.BorderColor = Color.FromHex("#4a2ca8");
            NextWeekBtn.BorderColor = Color.FromHex("#2f1f4f");
            NextMonthBtn.BorderColor = Color.FromHex("#4a2ca8");
            NextYearBtn.BorderColor = Color.FromHex("#4a2ca8");
        }

        private void NextMonthBtnClicked(object sender, EventArgs e) {
            showEvents = "Next Month";
            AllTimeBtn.BorderColor = Color.FromHex("#4a2ca8");
            NextWeekBtn.BorderColor = Color.FromHex("#4a2ca8");
            NextMonthBtn.BorderColor = Color.FromHex("#2f1f4f");
            NextYearBtn.BorderColor = Color.FromHex("#4a2ca8");
        }

        private void NextYearBtnClicked(object sender, EventArgs e) {
            showEvents = "Next Year";
            AllTimeBtn.BorderColor = Color.FromHex("#4a2ca8");
            NextWeekBtn.BorderColor = Color.FromHex("#4a2ca8");
            NextMonthBtn.BorderColor = Color.FromHex("#4a2ca8");
            NextYearBtn.BorderColor = Color.FromHex("#2f1f4f");
        }
    }
}