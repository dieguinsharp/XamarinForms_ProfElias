using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXL.Contents.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentPage3 :ContentPage {
        public ContentPage3() {
            InitializeComponent();

            btnPlay.Clicked += openNavegation;
        }

        private void openNavegation(object sender, EventArgs args) {
            //App.Current.MainPage = new NavigationPage(new Navegation.Page1());
            App.Current.MainPage = new Abas.Abas();
        }
    }
}