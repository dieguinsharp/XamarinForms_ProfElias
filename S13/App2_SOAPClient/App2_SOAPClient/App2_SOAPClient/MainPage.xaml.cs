using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2_SOAPClient {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage:ContentPage {
        public MainPage() {
            InitializeComponent();
        }
        private void btnEnviar(object sender, EventArgs args) {
            var Num1 = int.Parse(num1.Text);
            var Num2 = int.Parse(num2.Text);

             
            Resultados.Text = DependencyService.Get<IServiceSOAP>().Somar(Num1,Num2);
        }
    }
}
