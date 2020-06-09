using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S8_App02.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S8_App02.Paginas {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroPage:ContentPage {
        public CadastroPage() {
            InitializeComponent();
        }
        private byte prioridade { get; set; }
        public void PrioridadeSelectAction(object sender,EventArgs args) {

            var Stacks = SLPrioridades.Children;

            foreach(var Linha in Stacks) {
                Label lblPrioridade = ((StackLayout)Linha).Children[1] as Label;
                lblPrioridade.TextColor = Color.Gray;
            }

            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
            FileImageSource Source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;
            String prioridade = Source.File.ToString().Replace("Resources/p","").Replace(".png","").Replace("p","");

            this.prioridade = byte.Parse(prioridade);
            
        }

        private void SalvarAction(object sender, EventArgs args) {
            bool erroExist = false;
            if(txtNome.Text == null || txtNome.Text.Trim().Length <= 0) {
                DisplayAlert("Erro","Nome não preenchido!","OK");
                erroExist = true;
            }

            if(this.prioridade <= 0) {
                DisplayAlert("Erro","Defina uma prioridade!","OK");
                erroExist = true;
            }

            if(erroExist == false) {
                Tarefa tarefa = new Tarefa();
                tarefa.nome = txtNome.Text.Trim();
                tarefa.prioridade = this.prioridade;

                new Armazenamento().Salvar(tarefa);
                App.Current.MainPage = new NavigationPage(new InicioPage());

            }
        }
    }
}