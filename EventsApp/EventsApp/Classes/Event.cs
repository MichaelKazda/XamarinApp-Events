﻿using System;
namespace EventsApp.Classes
{
    public class Event
    {
        public string Name { get; set; }
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

        public Event()
        {
            SetTimeFromTo();
            SetTimeRemaining();
        }

        public void SetTimeFromTo()
        {

        }

        public void SetTimeRemaining()
        {

        }

    }
}
