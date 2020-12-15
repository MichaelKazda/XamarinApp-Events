using System;
namespace EventsApp.Classes
{
    public class Event
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public string Place { get; set; }
        public int TimestampFrom { get; set; }
        public int TimestampTo { get; set; }
        public bool YearlyRepeat { get; set; }
    }
}
