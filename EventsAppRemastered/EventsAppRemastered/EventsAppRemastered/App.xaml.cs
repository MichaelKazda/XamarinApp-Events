using EventsAppRemastered.Database;
using EventsAppRemastered.Pages;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventsAppRemastered {
    public partial class App : Application {

        public static EventDB Database { get; set; }

        public App() {
            InitializeComponent();

            if (Database == null) {
                Database = new EventDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Events.db3"));
            }

            MainPage = new SingUpPage();
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
