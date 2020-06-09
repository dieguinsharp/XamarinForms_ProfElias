using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_ControleXF.Conteudo {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewPage:ContentPage {
        public WebViewPage() {
            InitializeComponent();
        }

        private void openSite(object sender, EventArgs args) {
            navegador.Source = txtSite.Text; 
        }
        private void openProx(object sender,EventArgs args) {
            if(navegador.CanGoForward) {
                navegador.GoForward();
            }
        }
        private void openVoltar(object sender,EventArgs args) {
            if(navegador.CanGoBack) {
                navegador.GoBack();
            }
        }
        private void openCarregado(object sender,EventArgs args) {
            lblStatus.Text = "Finalizado...";
        }
        private void openCarregando(object sender,EventArgs args) {
            lblStatus.Text = "Carregando...";
        }
    }
}