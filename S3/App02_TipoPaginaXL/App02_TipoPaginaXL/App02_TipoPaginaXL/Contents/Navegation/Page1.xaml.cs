using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXL.Contents.Navegation {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 :ContentPage {
        public Page1() {
            InitializeComponent();

            btnParaPage2.Clicked += mudarPage;
            btnParaModal.Clicked += chamarModal;
            btnParaMenu.Clicked += chamarMenu;

        }
        private void mudarPage(object sender, EventArgs args) {
            Navigation.PushAsync(new Page2());
        }
        private void chamarModal(object sender, EventArgs args) {
            Navigation.PushModalAsync(new Modal());
        }
        private void chamarMenu(object sender,EventArgs args) {
            App.Current.MainPage = new Menu_Lateral.Master();
        }
    }
}