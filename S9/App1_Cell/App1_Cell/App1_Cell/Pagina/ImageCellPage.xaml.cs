using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Cell.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace App1_Cell.Pagina {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageCellPage:ContentPage {
        public ImageCellPage() {
            InitializeComponent();
            List<Funcionarios> list = new List<Funcionarios>();

            list = Salvar.Puxar();
            ListFuncionarios.ItemsSource = list;
        }
    }
}