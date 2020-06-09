using App1_Vagas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Vagas.Banco;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using Xamarin.Forms.Xaml;

namespace App1_Vagas.Paginas {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastrarVagasPage:ContentPage {
        public CadastrarVagasPage() {
            InitializeComponent();

        }
        int i = 0;
        public void SalvarAction(object sender, EventArgs args) {
            Vagas vaga = new Vagas();
            if(nomevaga.Text != string.Empty & nomevaga.Text != null & nomevaga.Text.Length > 5) {
                vaga.nomevaga = nomevaga.Text;
                if(int.TryParse(quantidade.Text,out i) & quantidade.Text != null & Convert.ToInt32(quantidade.Text) > 0) {
                    vaga.qntdvagas = short.Parse(quantidade.Text);
                    if(salario.Text != null & int.TryParse(salario.Text,out i) & Convert.ToInt32(salario.Text) > 0) {
                        vaga.salario = Convert.ToDouble(salario.Text);
                        vaga.tipocontratacao = (switchh.IsToggled == true) ? Convert.ToString("PJ") : Convert.ToString("CLT");
                        if(telefone.Text != null & telefone.Text.Length >= 8) {
                            vaga.telefone = telefone.Text;
                            if(editor.Text != null & editor.Text.Length > 20 ) {
                                vaga.descricao = editor.Text;
                                if(empresa.Text != null & empresa.Text.Length >= 4) {
                                    vaga.empresa = empresa.Text;
                                    if(cidade.Text != null & cidade.Text.Length > 0) {
                                        vaga.cidade = cidade.Text;
                                        if (email.Text != null & email.Text.Length >= 8) {
                                            vaga.email = email.Text;

                                            AcessoBanco bdd = new AcessoBanco();
                                            bdd.Cadastro(vaga);

                                            App.Current.MainPage = new NavigationPage(new ConsultarVagasPage());
                                        } else {
                                            DisplayAlert("Error","Digite um email válido!","Corrigir");
                                            email.Focus();
                                        }
                                    } else {
                                        DisplayAlert("Error","Digite um nome válido para a cidade.", "Corrigir");
                                        cidade.Focus();
                                    }
                                } else {
                                    DisplayAlert("Error","O nome da empresa deve ser maior","Corrigir");
                                    empresa.Focus();
                                }
                            } else {
                                DisplayAlert("Error","A descrição deve conter mais detalhes.","Corrigir");
                                editor.Focus();
                            }
                        } else {
                            DisplayAlert("Error","Digite um telefone válido!","Corrigir");
                            telefone.Focus();
                        }
                    } else {
                        DisplayAlert("Error","Defina um salário válido.","Corrigir");
                        salario.Focus();
                    }
                } else {
                    DisplayAlert("Error","Defina uma quantidade de vagas válida.","Corrigir");
                    quantidade.Focus();
                }
            } else {
                DisplayAlert("Error","O nome da vaga deve ter no minimo 5 caracteres.","Corrigir");
                nomevaga.Focus();
            }  
        }
    }
}