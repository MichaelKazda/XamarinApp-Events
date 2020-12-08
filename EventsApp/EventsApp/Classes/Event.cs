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


        /**
        public Event(string _name, string _desc, string _place, int _timestampFrom, int _timestampTo, bool _yearlyRepeat, int _yearsCounter)
        {
            Name = _name;
            Note = _desc;
            Place = _place;
            TimestampFrom = _timestampFrom;
            TimestampTo = _timestampTo;
            YearlyRepeat = _yearlyRepeat;
            YearsCounter = _yearsCounter;
        }
        */

    }
}
