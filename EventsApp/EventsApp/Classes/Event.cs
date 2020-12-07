using System;
namespace EventsApp.Classes
{
    public class Event
    {
        private string Name;
        private string Note;
        private string Place;

        public Event(string _name, string _desc)
        {
            Name = _name;
            Note = _desc;
        }

    }
}
