using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.ComponentModel;
using App1_Mimica.Model;
using App1_Mimica.Armazenamento;
using Xamarin.Forms;

namespace App1_Mimica.ViewModel {
    public class ResultadoModel:INotifyPropertyChanged {

        public Command JogarNovamenteAction { get; set; }
        public Jogo JogoObj { get; set; }

        public ResultadoModel() {
            JogoObj = Banco.Jogo;
            JogarNovamenteAction = new Command(JogarNovamente);
        }

        private void JogarNovamente() {
            App.Current.MainPage = new View.InicioPage();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string NameProperty) {
            if(PropertyChanged != null) {
                PropertyChanged(this,new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
