using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S8_App02 {
    public partial class App:Application {
        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new Paginas.InicioPage());
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
