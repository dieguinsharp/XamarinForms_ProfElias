using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_LayoutXL {
    public partial class App :Application {
        public App() {
            InitializeComponent();

            MainPage = new App02_LayoutXL.Master.Menu();
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
