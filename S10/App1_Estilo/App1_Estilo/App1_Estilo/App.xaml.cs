﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Estilo {
    public partial class App:Application {
        public App() {
            InitializeComponent();

            MainPage = new App1_Estilo.Menu.Menu();
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
