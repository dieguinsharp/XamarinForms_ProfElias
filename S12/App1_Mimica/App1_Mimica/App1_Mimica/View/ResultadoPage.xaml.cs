using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Mimica.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Mimica.View {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultadoPage:ContentPage {
        public ResultadoPage() {
            InitializeComponent();

            BindingContext = new ResultadoModel();
        }
    }
}