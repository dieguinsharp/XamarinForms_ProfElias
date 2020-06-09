using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Mimica.View.Util {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cabecalho:ContentView {
        public Cabecalho() {
            InitializeComponent();

            BindingContext = new ViewModel.Cabecalho();
        }

        private void SairEvent(object sender, EventArgs args) {
            // App.Current.MainPage = new InicioPage();
            var viewModel = (ViewModel.Cabecalho)this.BindingContext;

            if(viewModel.Sair.CanExecute(null)) {
                viewModel.Sair.Execute(null);
            }
        }
    }
}