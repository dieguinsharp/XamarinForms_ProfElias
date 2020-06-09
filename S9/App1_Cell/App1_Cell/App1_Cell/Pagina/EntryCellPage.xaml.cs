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
    public partial class EntryCellPage:ContentPage {
        public EntryCellPage() {
            InitializeComponent();
        }
        public void salvar(object sender, EventArgs args) {
            Funcionarios func = new Funcionarios();
            func.cargo = cargo.Text;
            func.foto = "perfil.png";
            func.nome = funcionario.Text;

            Salvar.salvar(func);
        }

    }
}