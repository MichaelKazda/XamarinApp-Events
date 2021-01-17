using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EventsAppRemastered.Popups;
using EventsApp.Database;
using EventsAppRemastered.Database;

namespace EventsAppRemastered.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEventPage : ContentPage {

        public static EventDB EventDatabase;

        public AddEventPage(EventDB _EventDatabase) {
            InitializeComponent();
            EventDatabase = _EventDatabase;

            // set minimum date to datepicker
            DateTime minDate = DateTime.Now;
            DatePicker.MinimumDate = minDate;
        }

        private void AddEventButton_Clicked(object sender, EventArgs e) {
            ConstructEvent();
        }

        private async void CreateEvent(Event evn) {
            await EventDatabase.SaveEventAsync(evn);
        }

        private void ConstructEvent() {
            if (NameLabel.Text != null && DatePicker.Date != null && TimePickerFrom.Time != null && TimePickerTo.Time != null) {

                DateTime date = DatePicker.Date;
                TimeSpan timeFrom = TimePickerFrom.Time;
                TimeSpan timeTo = TimePickerTo.Time;

                string timeFromMinutes = timeFrom.Minutes.ToString();
                if (timeFromMinutes.Length == 1)
                    timeFromMinutes += "0";

                string timeToMinutes = timeTo.Minutes.ToString();
                if (timeToMinutes.Length == 1)
                    timeToMinutes += "0";

                // mandatory inputs
                Event evn = new Event() {
                    Name = NameLabel.Text.ToString(),
                    UserName = App._UserName, // Author of Event
                    Date = date,
                    TimeFrom = timeFrom,
                    TimeTo = timeTo,
                    DateString = $"{date.Day}.{date.Month}.{date.Year}",
                    TimeFromToString = $"{timeFrom.Hours}:{timeFromMinutes} - {timeTo.Hours}:{timeToMinutes}"
            };

                // event start
                evn.EventStartDate = DatePicker.Date.Add(TimePickerFrom.Time);

                // not mandatory
                if (NoteLabel.Text != null)
                    evn.Note = NoteLabel.Text.ToString();

                if (YearsCounterLabel.Text != null) {
                    evn.YearlyCounter = YearsCounterLabel.Text.ToString();
                    evn.YearlyCounterString = $"{YearsCounterLabel.Text} anniversary";
                }

                if (YearsCounterLabel.Text != null) {
                    evn.YearlyRepeat = RepeatSwitch.IsToggled;
                    if (RepeatSwitch.IsToggled)
                        evn.YearlyRepeatString = "Repeated Yearly";
                }    

                if (PlaceLabel.Text != null)
                    evn.Place = PlaceLabel.Text.ToString();

                if (ColorPicker.SelectedItem != null) {
                    if (ColorPicker.SelectedItem.ToString() == "Purple") {
                        evn.Color = "#4a2ca8";
                    } else {
                        evn.Color = ColorPicker.SelectedItem.ToString();
                    }
                } else {
                    evn.Color = "#4a2ca8";
                }
                    

                CreateEvent(evn);
                Toaster.Toast("Event created");
                Navigation.PopAsync();
            } else {
                Toaster.Toast("You must fill mandatory fields");
            }
                
        } 
    }
}