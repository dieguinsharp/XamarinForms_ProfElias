using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXL.Contents.Abas {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Abas : TabbedPage {
        public Abas() {
            InitializeComponent();
            
            Children.Add(new NavigationPage(new Navegation.Page1()) { Title = "Página 1" });
            Children.Add(new NavigationPage(new Navegation.Page2()) { Title = "Página 2" });
            Children.Add(new NavigationPage(new Navegation.Modal()) { Title = "Página 3" });
        }
    }
}