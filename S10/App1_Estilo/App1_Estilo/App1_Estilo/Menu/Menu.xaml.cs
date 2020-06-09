using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Estilo.Paginas;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Estilo.Menu {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu: MasterDetailPage {
        public Menu() {
            InitializeComponent();
        }
        private void GoPage1(object sender, EventArgs args) {
            Detail = new NavigationPage(new ImplicitStyle());
            IsPresented = false;
        }

        private void GoPage2(object sender,EventArgs args) {
            Detail = new NavigationPage(new Explicity_Style());
            IsPresented = false;
        }

        private void GoPage3(object sender, EventArgs args) {
            Detail = new NavigationPage(new GlobalStyle());
            IsPresented = false;
        }

        private void GoPage4(object sender,EventArgs args) {
            Detail = new NavigationPage(new InheritStyle());
            IsPresented = false;
        }

        private void GoPage5(object sender,EventArgs args) {
            Detail = new NavigationPage(new DynamicStyle());
            IsPresented = false;
        }
    }
}