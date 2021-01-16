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

                string timeFromMinutesString = timeFrom.Minutes.ToString();
                string timeToMinutesString = timeTo.Minutes.ToString();

                if (timeFromMinutesString == "0")
                    timeFromMinutesString += "0";

                if (timeToMinutesString == "0")
                    timeToMinutesString += "0";

                string timeFromToString = $"{timeFrom.Hours}:{timeFromMinutesString} - {timeTo.Hours}:{timeToMinutesString}";


                // mandatory inputs
                Event evn = new Event() { 
                    Name = NameLabel.Text.ToString(),
                    Date = date,
                    TimeFrom = TimePickerFrom.Time,
                    TimeTo = TimePickerTo.Time,
                    DateString = $"{date.Day}.{date.Month}.{date.Year}",
                    TimeFromToString = 
            };

                // event start
                evn.EventStartDate = DatePicker.Date.Add(TimePickerFrom.Time);

                // not mandatory
                if (NoteLabel.Text != null)
                    evn.Note = NoteLabel.Text.ToString();

                if (YearsCounterLabel.Text != null) {
                    evn.YearlyCounter = YearsCounterLabel.Text.ToString();
                    evn.YearlyRepeat = RepeatSwitch.IsToggled;
                }    

                if (PlaceLabel.Text != null)
                    evn.Place = PlaceLabel.Text.ToString();

                if (ColorPicker.ToString() != "") {
                    if (ColorPicker.Title.ToString() == "Purple") {
                        evn.Color = "#4a2ca8";
                    } else {
                        evn.Color = ColorPicker.Title.ToString();
                    }
                } else {
                    evn.Color = "#4a2ca8";
                }
                    

                CreateEvent(evn);
                Toaster.Toast("Event created");
            } else {
                Toaster.Toast("You must fill mandatory fields");
            }
                
        } 
    }
}