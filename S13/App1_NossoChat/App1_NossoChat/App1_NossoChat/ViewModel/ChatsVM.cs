using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using App1_NossoChat.Model;
using Xamarin.Forms;
using App1_NossoChat.Services;
using System.Threading.Tasks;

namespace App1_NossoChat.ViewModel {
    class ChatsVM:INotifyPropertyChanged {

        private bool _mensagemErro;
        public bool MensagemErro { get { return _mensagemErro; } set { _mensagemErro = value; OnPropertyChanged("MensagemErro"); } }


        private string _msg;
        public string msg { get { return _msg; } set { _msg = value; OnPropertyChanged("msg"); } }
        public Command Adicionar { get; set; }
        public Command Atualizar { get; set; }

        private Chat _SelectedChat;

        public Chat SelectedChat { get { return _SelectedChat; } set { _SelectedChat = value; OnPropertyChanged("SelectedChat"); GoPaginaMensagem(value); } }

        private bool _carregando;

        public bool carregando { get { return _carregando; } set { _carregando = value; OnPropertyChanged("carregando"); } }



        private List<Chat> _chatsList;
        public List<Chat> chatsLISTA { 
            get { 
                return _chatsList;
            } set { 
                _chatsList = value; 
                OnPropertyChanged("chatsLISTA"); 
            } }
        public ChatsVM() {
           Task.Run(() => CarregarChat());
            Adicionar = new Command(AdicionarAct);
            Atualizar = new Command(AtualizarAct);

        }

        private async Task CarregarChat() {
            try {
                MensagemErro = false;
                carregando = true;
                chatsLISTA = await ServiceREST.GetChat();
                carregando = false;
            } catch (Exception e) {
                carregando = false;
                MensagemErro = true;
            }
            
        }

        private void AdicionarAct() {
            ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.CadastrarChat());
        }
        private void AtualizarAct() {
            Task.Run(() => CarregarChat());
        }

        private void GoPaginaMensagem(Chat chat) {
            if (chat != null) {
                SelectedChat = null;
                ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.Mensagem(chat) { Title = chat.nome});
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
