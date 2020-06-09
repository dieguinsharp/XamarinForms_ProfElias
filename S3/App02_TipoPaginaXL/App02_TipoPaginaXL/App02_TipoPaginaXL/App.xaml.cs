using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXL {
    public partial class App :Application {
        public App() {
            InitializeComponent();

            MainPage = new Contents.Pages.IntroducaoApp();
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
