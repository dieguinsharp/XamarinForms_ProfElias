using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_ControleXF.Conteudo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBarPage : ContentPage
    {
        private List<string> EmpresasTI = new List<string>();
        public SearchBarPage()
        {
            InitializeComponent();
            
            EmpresasTI.Add("Microsoft");
            EmpresasTI.Add("Apple");
            EmpresasTI.Add("Oracle");
            EmpresasTI.Add("IBM");
            EmpresasTI.Add("SAP");
            EmpresasTI.Add("Uber");
            EmpresasTI.Add("99Taxi");

            Preencher(EmpresasTI);

        }

        private void Preencher(List<string> empresasTI) {
            listResult.Children.Clear();
            foreach(var emp in empresasTI) {
                listResult.Children.Add(new Label { Text = emp });
            }
        }

        private void Pesquisar(object sender, TextChangedEventArgs args) {
            var resultado = EmpresasTI.Where(a => a.Contains(args.NewTextValue)).ToList<String>();
            Preencher(resultado);
        }

        private void PesquisarButton(object sender,EventArgs args) {
            var resultado = EmpresasTI.Where(a => a.Contains(((SearchBar)sender).Text)).ToList<String>();
            Preencher(resultado);
        }
    }
}