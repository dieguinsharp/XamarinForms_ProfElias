using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Cell.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Cell.Pagina {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewButtonlPage:ContentPage {
        public ListViewButtonlPage() {
            InitializeComponent();

            List<Funcionarios> list = new List<Funcionarios>();
            list.Add(new Funcionarios() { cargo = "Pedrerage",foto = "perfil.png",nome = "Diego" });
            list.Add(new Funcionarios() { cargo = "Adm",foto = "perfil.png",nome = "Ruan" });
            list.Add(new Funcionarios() { cargo = "Motorista",foto = "perfil.png",nome = "Vagner" });
            list.Add(new Funcionarios() { cargo = "Entregador",foto = "perfil.png",nome = "Mauro" });
            list.Add(new Funcionarios() { cargo = "Designer",foto = "perfil.png",nome = "Joana" });
            list.Add(new Funcionarios() { cargo = "Cozinheira",foto = "perfil.png",nome = "Maria" });

            lstView.ItemsSource = list;
        }
        private void FeriasAction(object sender, EventArgs args) {
            Button btnFerias = (Button)sender;
            Funcionarios func = (Funcionarios)btnFerias.CommandParameter;

            DisplayAlert("Férias","Funcionario: " + func.nome,"OK");

        }
    }
}