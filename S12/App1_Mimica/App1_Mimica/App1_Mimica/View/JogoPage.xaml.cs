using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Mimica.Model;
using App1_Mimica.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Mimica.View {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JogoPage:ContentPage {
        public JogoPage(Grupo grupo) {
            InitializeComponent();

            BindingContext = new JogoModel(grupo);
        }
    }
}