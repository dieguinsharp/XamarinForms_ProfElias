using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_ControleXF.Modelo;

namespace App1_ControleXF.Conteudo {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage:ContentPage {
        public ListViewPage() {
            InitializeComponent();

            List<Pessoa> list = new List<Pessoa>();
            list.Add(new Pessoa() { nome = "José",idade = "30" });
            list.Add(new Pessoa() { nome = "Maria",idade = "34" });
            list.Add(new Pessoa() { nome = "Felipe",idade = "22" });
            list.Add(new Pessoa() { nome = "João",idade = "17" });
            list.Add(new Pessoa() { nome = "Diego",idade = "26" });
            listaPessoa.ItemsSource = list;
        }
    }
}