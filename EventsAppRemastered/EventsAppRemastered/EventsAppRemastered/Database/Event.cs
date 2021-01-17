using SQLite;
using System;
using System.Drawing;

namespace EventsApp.Database {
    public class Event {

        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        [NotNull] public string Name { get; set; }
        public string Note { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public DateTime EventStartDate { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
        public string YearlyCounter { get; set; }
        public bool YearlyRepeat { get; set; } 

        public string TimeToStart { get; set; }
        public string Color { get; set; }
        public string YearlyRepeatString { get; set; }
        public string YearlyCounterString { get; set; }

        public string DateString { get; set; }
        public string TimeFromToString { get; set; }
    }

}

