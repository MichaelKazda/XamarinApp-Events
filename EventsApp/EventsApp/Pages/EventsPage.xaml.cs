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

        public Event EventViewModel { get; private set; }

        public EventsPage() {
            InitializeComponent();

            // remove nav bar
            NavigationPage.SetHasNavigationBar(this, false);

            // this 
            EventViewModel = new Event();
            BindingContext = EventViewModel;

            ObservableCollection<Event> events = new ObservableCollection<Event>();
            Event evn = new Event() {
                Name = "neco"       
            };
            events.Add(evn);
            EventsListView.ItemsSource = events;

        }

        private void AddEventButton_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new AddEventPage());
        }
    }
}