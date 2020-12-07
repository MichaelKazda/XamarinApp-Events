using System;
namespace EventsApp.Classes
{
    public class Event
    {
        private string Name;
        private string Note;
        private string Place;
        private int TimestampFrom;
        private int TimestampTo;
        private bool YearlyRepeat;
        private int YearsCounter;

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

    }
}
