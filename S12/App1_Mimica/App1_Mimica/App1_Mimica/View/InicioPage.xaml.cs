using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Mimica.View {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage:ContentPage {
        public InicioPage() {
            InitializeComponent();
            BindingContext = new ViewModel.InicioModel();
        }
        /*public class Grupo : INotifyPropertyChanged {
            private string _nomeGrupo1;
            string nomeGrupo1 { get { return _nomeGrupo1; } set { _nomeGrupo1 = value; PropriedadeChaged("nomeGrupo1"); } }

            public Grupo() {
                nomeGrupo1 = "Os Machos";
                
                
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void PropriedadeChaged(string nomePropriedade) {
                
                if (PropertyChanged != null) {
                    PropertyChanged(this,new PropertyChangedEventArgs(nomePropriedade));
                }
            }
            */
        }
    }
