using App1_Vagas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Vagas.Banco;
using App1_Vagas.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Vagas.Paginas {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarVagasPage:ContentPage {
        private Vagas vaga2 { get; set; }
        public EditarVagasPage(Vagas vaga) {
            InitializeComponent();

            this.vaga2 = vaga;
            cidade.Text = vaga2.cidade;
            editor.Text = vaga2.descricao;
            email.Text = vaga2.email;
            empresa.Text = vaga2.empresa;
            nomevaga.Text = vaga2.nomevaga;
            quantidade.Text = vaga2.qntdvagas.ToString();
            salario.Text = vaga2.salario.ToString();
            telefone.Text = vaga2.telefone;
            switchh.IsToggled = (vaga.tipocontratacao == "PJ") ? true : false;
        }

        public void SalvarAction(object sender, EventArgs args) {
            vaga2.nomevaga = nomevaga.Text;
            vaga2.qntdvagas = short.Parse(quantidade.Text);
            vaga2.salario = Convert.ToDouble(salario.Text);
            vaga2.tipocontratacao = (switchh.IsToggled == true) ? Convert.ToString("PJ") : Convert.ToString("CLT");
            vaga2.telefone = telefone.Text;
            vaga2.email = email.Text;
            vaga2.descricao = editor.Text;
            vaga2.empresa = empresa.Text;
            vaga2.cidade = cidade.Text;

            AcessoBanco bdd = new AcessoBanco();
            bdd.Atualizacao(vaga2);

            App.Current.MainPage = new NavigationPage(new MinhasVagasCadastradasPage());
        }
    }
}