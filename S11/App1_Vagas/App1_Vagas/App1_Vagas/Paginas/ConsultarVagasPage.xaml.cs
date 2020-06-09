using App1_Vagas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Vagas.Banco;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Vagas.Paginas {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarVagasPage:ContentPage {
        public List<Vagas> lista { get; set; }
        public ConsultarVagasPage() {
            InitializeComponent();

            att();


        }
        public void att() {
            AcessoBanco bdd = new AcessoBanco();
            lista = bdd.Consultar();
            qntdVagas.Text = "Quantidade Atual de vagas: " + Convert.ToString(lista.Count);
            listVagas.ItemsSource = lista;
        }
        public void GoCadastro(object sender,EventArgs args) {
            Navigation.PushAsync(new Paginas.CadastrarVagasPage());
        }

        public void GoMinhasVagas(object sender,EventArgs args) {
            Navigation.PushAsync(new Paginas.MinhasVagasCadastradasPage());

        }

        public void MaisDetalhe(object sender, EventArgs args) {
            Label label = (Label)sender;
            Vagas vaga = ((TapGestureRecognizer)label.GestureRecognizers[0]).CommandParameter as Vagas;
            Navigation.PushAsync(new Paginas.DetalharVagasPage(vaga));
        }

        public void Pesquisa(object sender, TextChangedEventArgs args) {
            listVagas.ItemsSource = lista.Where(a => a.nomevaga.Contains(args.NewTextValue)).ToList();
        }
    }
}