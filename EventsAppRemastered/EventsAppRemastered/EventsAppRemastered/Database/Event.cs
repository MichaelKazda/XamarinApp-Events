using SQLite;
using System;

namespace EventsApp.Database {
    public class Event {

        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        [NotNull] public string Name { get; set; }
        public string Note { get; set; }
        public string Place { get; set; }
        public string Date { get; set; }
        public string TimeRemaining { get; set; }
        public string TimeFromTo { get; set; }

        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public int TimestampFrom { get; set; }
        public int TimestampTo { get; set; }

        public bool YearlyRepeat { get; set; }

        
    }

}

