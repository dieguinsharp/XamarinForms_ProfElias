using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using App1_NossoChat.Model;
using System.Threading.Tasks;
using App1_NossoChat.Services;

namespace App1_NossoChat.ViewModel {
    class CadastrarChatVM:INotifyPropertyChanged {
        private bool _mensagemErro;
        public bool MensagemErro { get { return _mensagemErro; } set { _mensagemErro = value; OnPropertyChanged("MensagemErro"); } }

        private bool _carregando;
        public bool carregando { get { return _carregando; } set { _carregando = value; OnPropertyChanged("carregando"); } }

        private string _msg;
        public string msg  { get { return _msg; } set { _msg = value; OnPropertyChanged("msg"); } }
        public Command CadastrarChat { get; set; }
        public string Nome { get; set; }

        public CadastrarChatVM() {
            CadastrarChat = new Command(CadastroDeChat);
        }
        public void CadastroDeChat() {
            bool x = Task.Run(() => Cadastrar()).GetAwaiter().GetResult();
            if (x == true) {
                var PaginaAtual = ((NavigationPage)App.Current.MainPage);
                PaginaAtual.PopAsync();
            }
        }
        private async Task<bool> Cadastrar() {
            carregando = true;
            MensagemErro = false;
            try {

                var chat = new Chat() {nome = Nome };
                bool ok = await ServiceREST.InsertChat(chat);
                if(ok == true) {
                    var PaginaAtual = ((NavigationPage)App.Current.MainPage);

                    var Chats = (View.Chats)PaginaAtual.RootPage;
                    var ViewModel = (ChatsVM)Chats.BindingContext;
                    if(ViewModel.Atualizar.CanExecute(null)) {
                        ViewModel.Atualizar.Execute(null);
                    }

                    return true;
                } else {
                    msg = "Ocorreu um erro no cadastro!";
                    carregando = false;
                    return false;
                }
            } catch(Exception e) {
                MensagemErro = true;
                msg = e.Message;
                carregando = false;
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string nomeProperty) {
            if(PropertyChanged != null) {
                PropertyChanged(this,new PropertyChangedEventArgs(nomeProperty));
            }
        }

    }
}
