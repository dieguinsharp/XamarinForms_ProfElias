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
    public partial class ListViewPage:ContentPage {
        public ListViewPage() {
            InitializeComponent();

            List<Funcionarios> list = new List<Funcionarios>();
            list.Add(new Funcionarios() { cargo = "Pedrerage",foto = "perfil.png",nome = "Diego" });

            lstView.ItemsSource = list;
        }
        private void ItemSelecionado(object sender, SelectedItemChangedEventArgs args) {
            Funcionarios func = (Funcionarios)args.SelectedItem;

            Navigation.PushAsync(new Pagina.Detalhe.DetailPage(func));
        }
    }
}