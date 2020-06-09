using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using App1_Mimica.Model;
using Xamarin.Forms;
using System.Runtime.InteropServices;

namespace App1_Mimica.ViewModel {
    class InicioModel : INotifyPropertyChanged {
        private string _MsgError;
        public string MsgError { get { return _MsgError; } set { _MsgError = value; OnPropertyChanged("MsgError"); } }
        public Jogo Jogo { get; set; }
        public Command IniciarCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public InicioModel() {
            IniciarCommand = new Command(IniciarJogo);
            Jogo = new Jogo();
            Jogo.Grupo1 = new Grupo();
            Jogo.Grupo2 = new Grupo();

            Jogo.TempoPalavra = 120;
            Jogo.Rodadas = 7;
        }

        private void IniciarJogo() {

            string error = "";
            if (Jogo.TempoPalavra < 10) {
                error += "O tempo minimo para cada palavra é 10 segundos.";
            }
            if (Jogo.Rodadas <= 0) {
                error += "\nO valor minimo de rodadas é 1";
            }
            if(error.Length > 0) {
                MsgError = error;
            } else {
                Armazenamento.Banco.Jogo = this.Jogo;
                Armazenamento.Banco.RodadaAtual = 1;
                App.Current.MainPage = new View.JogoPage(Jogo.Grupo1);
            }


            
        }
        private void OnPropertyChanged(string NameProperty) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }

        }
    }
}
