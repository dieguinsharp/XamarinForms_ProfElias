using App1_Mimica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using App1_Mimica.Armazenamento;
using App1_Mimica.View;

namespace App1_Mimica.ViewModel {
    public class JogoModel : INotifyPropertyChanged {
        public Grupo GrupoObj { get; set; }

        public string NomeGrupo { get; set; }
        public string NumeroGrupo { get; set; }

        private byte _PalavraPontuacao;
        public byte PalavraPontuacao { get { return _PalavraPontuacao; } set { _PalavraPontuacao = value; OnPropertyChanged("PalavraPontuacao"); } }

        private string _palavra;
        public string Palavra { get { return _palavra; } set { _palavra = value; OnPropertyChanged("Palavra"); } }

        private string _TextoContagem;
        public string TextoContagem { get { return _TextoContagem; } set { _TextoContagem = value; OnPropertyChanged("TextoContagem"); } }

        private bool _IsVisibleBtnMostrar;
        public bool IsVisibleBtnMostrar { get { return _IsVisibleBtnMostrar; } set { _IsVisibleBtnMostrar = value; OnPropertyChanged("IsVisibleBtnMostrar"); } }

        private bool _IsVisibleContagem;
        public bool IsVisibleContagem { get { return _IsVisibleContagem; } set { _IsVisibleContagem = value; OnPropertyChanged("IsVisibleContagem"); } }

        private bool _IsVisibleAE;
        public bool IsVisibleAE { get { return _IsVisibleAE; } set { _IsVisibleAE = value; OnPropertyChanged("IsVisibleAE"); } } 

        private bool _IsVisibleButtonIniciar;
        public bool IsVisibleButtonIniciar { get { return _IsVisibleButtonIniciar; }  set { _IsVisibleButtonIniciar = value; OnPropertyChanged("IsVisibleButtonIniciar"); } }

        public Command MostrarPalavra { get; set; }
        public Command Acertou { get; set; }
        public Command Iniciar { get; set; }
        public Command Errou { get; set; }

        public JogoModel(Grupo grupo) {
            GrupoObj = grupo;
            NomeGrupo = grupo.NomeGrupo;

            if(grupo == Armazenamento.Banco.Jogo.Grupo1) {
                NumeroGrupo = "Grupo 1: ";
            } else {
                NumeroGrupo = "Grupo 2: ";
            }

            IsVisibleContagem = false;
            IsVisibleButtonIniciar = false;
            IsVisibleBtnMostrar = true;
            IsVisibleAE = false;
            Palavra = "******";

            MostrarPalavra = new Command(MostrarPalavraAction);
            Acertou = new Command(AcertouAction);
            Errou = new Command(ErrouAction);
            Iniciar = new Command(IniciarAction);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void MostrarPalavraAction() {           
            var NumNivel = Armazenamento.Banco.Jogo.NivelNumerico;
            if(NumNivel == 0) {
                Random rd = new Random();
                int niv = rd.Next(0,3);
                int ind = rd.Next(0,Banco.Palavras[niv].Length);
                Palavra = Banco.Palavras[niv][ind];
                PalavraPontuacao = (byte) ((niv == 0) ? 1 : (niv == 1) ? 3 : 5);
            }
            if(NumNivel == 1) {
                Random rd = new Random();
                int ind = rd.Next(0,Banco.Palavras[NumNivel - 1].Length);
                Palavra = Banco.Palavras[NumNivel - 1][ind];
                PalavraPontuacao = 1;
            }
            if(NumNivel == 2) {
                Random rd = new Random();
                int ind = rd.Next(0,Banco.Palavras[NumNivel - 1].Length);
                Palavra = Banco.Palavras[NumNivel - 1][ind];
                PalavraPontuacao = 3;
            }
            if(NumNivel == 3) {
                Random rd = new Random();
                int ind = rd.Next(0,Banco.Palavras[NumNivel - 1].Length);
                Palavra = Banco.Palavras[NumNivel - 1][ind];
                PalavraPontuacao = 5;
            }


            IsVisibleBtnMostrar = false;
            IsVisibleButtonIniciar = true;
        }

        private void IniciarAction() {
            IsVisibleButtonIniciar = false;
            IsVisibleContagem = true;
            IsVisibleAE = true;

            int i = Armazenamento.Banco.Jogo.TempoPalavra;
            TextoContagem += i.ToString();
            i--;
            Device.StartTimer(TimeSpan.FromSeconds(1), ()=> {
                TextoContagem = i.ToString();
                i--;
                if (i < 0) {
                    TextoContagem = "Tempo Esgotado!";
                }
                return true;
            });
        }

        private void ErrouAction() {
            GoProximoGrupo();
        }

        private void AcertouAction() {
            GrupoObj.PontuacaoGrupo += PalavraPontuacao;
            GoProximoGrupo();
        }

        private void GoProximoGrupo() {
            Grupo grupo;
            if(Armazenamento.Banco.Jogo.Grupo1 == GrupoObj) {
                grupo = Armazenamento.Banco.Jogo.Grupo2; 
            } else {
                grupo = Armazenamento.Banco.Jogo.Grupo1;
                Armazenamento.Banco.RodadaAtual += 1;
            }
            if(Armazenamento.Banco.RodadaAtual > Armazenamento.Banco.Jogo.Rodadas) {
                App.Current.MainPage = new ResultadoPage();
                
                
            } else {
                App.Current.MainPage = new JogoPage(grupo);
            }
            
        }

        private void OnPropertyChanged(string NameProperty) {
            if(PropertyChanged != null) {
                PropertyChanged(this,new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
