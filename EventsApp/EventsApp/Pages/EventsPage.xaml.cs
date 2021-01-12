using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsApp.Classes;
using Plugin.Toast;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventsApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsPage : ContentPage {

        public ObservableCollection<Event> Events { get; set; }

        public EventsPage() {
            InitializeComponent();

            // remove nav bar
            NavigationPage.SetHasNavigationBar(this, false);

            // set events collection
            Events = new ObservableCollection<Event>();

            // add testing event
            Event evn = new Event() {
                Name = "neco"       
            };
            Events.Add(evn);

            // bind to listview
            EventsListView.ItemsSource = Events;

        }

        private void AddEventButton_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new AddEventPage());
        }
    }
}