using App1_Mimica.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1_Mimica.ViewModel {
    class Cabecalho {
        public Command Sair { get; set; }

        public Cabecalho() {
            Sair = new Command(SairAction);
        }

        private void SairAction() {
            App.Current.MainPage = new InicioPage();
        }
    }
}
