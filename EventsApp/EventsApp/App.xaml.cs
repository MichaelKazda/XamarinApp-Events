﻿using EventsApp.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventsApp {
    public partial class App : Application {
        public App() {
            InitializeComponent();

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
