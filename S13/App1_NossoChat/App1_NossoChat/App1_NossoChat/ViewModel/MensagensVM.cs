using App1_NossoChat.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using App1_NossoChat.Model;
using Xamarin.Forms;
using App1_NossoChat.Services;
using App1_NossoChat.View;
using App1_NossoChat.Util;
using System.Threading.Tasks;

namespace App1_NossoChat.ViewModel {
    class MensagensVM : INotifyPropertyChanged {

        private bool _mensagemErro;
        public bool MensagemErro { get { return _mensagemErro; } set { _mensagemErro = value; OnPropertyChanged("MensagemErro"); } }

        private string _txtMensagem;

        public Command AAtualizarCommand { get; set; }
        public Command btnEnviar { get; set; }
        public string txtMensagem { get { return _txtMensagem; } set { _txtMensagem = value; OnPropertyChanged("txtMensagem"); } }

        private Chat chatid;

        private bool _carregando;

        public bool carregando { get { return _carregando; } set { _carregando = value; OnPropertyChanged("carregando"); } }


        private List<Mensagens> _msgs;
        public List<Mensagens> msgs { get { return _msgs; } set { _msgs = value; OnPropertyChanged("msgs");
            }
        }
                

        public MensagensVM(Chat chat) {
            Task.Run(() => CarregandoMsg());
            AAtualizarCommand = new Command(Atualizar);
            this.chatid = chat;
            btnEnviar = new Command(EnviarMensagem);

            /*Device.StartTimer(TimeSpan.FromSeconds(1),() => {
                Atualizar();
                return true;
            });*/
        }

        public async Task CarregandoMsg() {
            try {
                MensagemErro = false;
                carregando = true;
                msgs = await ServiceREST.GetMensagemChat(chatid);
                carregando = false;
            } catch (Exception e) {
                carregando = false;
                MensagemErro = true;
            }
            
        }

        private void Atualizar() {
            Task.Run(() => CarregandoMsg());
        }

        private void EnviarMensagem() {
            var msg = new Mensagens() {
                id_usuario = UsuarioUtil.GetUsuarioLogado().id,
                mensagem = txtMensagem,
                id_chat = chatid.id
            };
            ServiceREST.InsertMensagem(msg);
            Atualizar();
            txtMensagem = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomeProperty) {
            if(PropertyChanged != null) {
                PropertyChanged(this,new PropertyChangedEventArgs(nomeProperty));
            }
        }
    }
}
