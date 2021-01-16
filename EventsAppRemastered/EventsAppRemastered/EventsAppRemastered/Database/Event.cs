using SQLite;
using System;

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
    }

}

