using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using App1_NossoChat.Model;
using App1_NossoChat.Services;
using Newtonsoft;
using Newtonsoft.Json;
using App1_NossoChat.Util;

namespace App1_NossoChat.ViewModel {
    class PaginaInicialVM:INotifyPropertyChanged {

        private bool _mensagemErro;
        public bool MensagemErro { get { return _mensagemErro; } set { _mensagemErro = value; OnPropertyChanged("MensagemErro"); } }


        private bool _carregando;

        public bool carregando { get { return _carregando; } set { _carregando = value; OnPropertyChanged("carregando"); } }

        private string _nome;
        public string NomeUSER { get { return _nome; } set { _nome = value; OnPropertyChanged("NomeUSER"); } }

        private string _senha;
        public string SenhaUSER { get { return _senha; } set { _senha = value; OnPropertyChanged("SenhaUSER"); } }

        private string _msg;
        public string msg { get { return _msg; } set { _msg = value; OnPropertyChanged("msg"); } }
        public Command AcessarCommand { get; set; }

        public PaginaInicialVM() {
            AcessarCommand = new Command(AcessarAction);
        }

        private async void AcessarAction() {
            try {
                MensagemErro = false;
                carregando = true;
                var user = new Usuario();
                user.nome = NomeUSER;
                user.password = SenhaUSER;

                var usuarioLogado = await ServiceREST.GetUsuario(user);
                if(usuarioLogado == null) {
                    msg = "Nome de Usuário/Senha incorretos.";
                    carregando = false;
                    MensagemErro = false;
                } else {
                    UsuarioUtil.SetUsuarioLogado(usuarioLogado);
                    //App.Current.Properties["LOGIN"] = JsonConvert.SerializeObject(usuarioLogado);
                    App.Current.MainPage = new NavigationPage(new App1_NossoChat.View.Chats()) { BarBackgroundColor = Color.FromHex("#5ED055"),BarTextColor = Color.White };
                }
            } catch(Exception e) {
                MensagemErro = true;
            } finally {
                carregando = false;
            }
            
        }


        private void OnPropertyChanged(string nomeProperty) {
            if(PropertyChanged != null) {
                PropertyChanged(this,new PropertyChangedEventArgs(nomeProperty));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


    }
}
