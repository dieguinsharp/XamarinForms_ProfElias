using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App3_JWPAsync.Service;

namespace App3_JWPAsync {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage:ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private async void GetTokenAction(object sender, EventArgs args) {
            string resultado = await JWTService.GetToken(nome.Text,senha.Text);
            lblToken.Text = resultado;
        }

        private async void VerificarAction(object sender, EventArgs args) {
            string resultado = await JWTService.RespostaVerificar();
            lblResultado.Text = resultado;
        }
    }
}
