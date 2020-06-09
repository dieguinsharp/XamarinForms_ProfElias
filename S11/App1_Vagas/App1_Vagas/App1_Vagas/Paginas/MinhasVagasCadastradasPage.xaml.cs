using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Vagas.Modelos;
using App1_Vagas.Banco;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Vagas.Paginas {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MinhasVagasCadastradasPage:ContentPage {
        List<Vagas> list { get; set; }
        public MinhasVagasCadastradasPage() {
            InitializeComponent();

            att();
        }
        ConsultarVagasPage f1 = new ConsultarVagasPage();

        public void ApagarAction(object sender, EventArgs args) {
            Label lblApagar = (Label)sender;
            Vagas vaga = ((TapGestureRecognizer)lblApagar.GestureRecognizers[0]).CommandParameter as Vagas;

            AcessoBanco bdd = new AcessoBanco();
            bdd.Exclusao(vaga);
            att();   
        }
        public void GoCadastro(object sender,EventArgs args) {
            Navigation.PushAsync(new Paginas.CadastrarVagasPage());
        }

        public void EditarAction(object sender, EventArgs args) {
            Label lblEditar = (Label)sender;
            Vagas vaga = ((TapGestureRecognizer)lblEditar.GestureRecognizers[0]).CommandParameter as Vagas;
            Navigation.PushAsync(new Paginas.EditarVagasPage(vaga));
        }
        public void GoConsultarVagas(object sender, EventArgs args) {
            App.Current.MainPage = new NavigationPage(new ConsultarVagasPage());
        }
        private void att() {
            AcessoBanco bdd = new AcessoBanco();
            list = bdd.Consultar();
            lblCount.Text = "Quantidade Atual de vagas: " + Convert.ToString(list.Count);
            listVagas.ItemsSource = list;
        }
        public void Pesquisa(object sender,TextChangedEventArgs args) {
            listVagas.ItemsSource = list.Where(a => a.nomevaga.Contains(args.NewTextValue)).ToList();
        }
    }
}