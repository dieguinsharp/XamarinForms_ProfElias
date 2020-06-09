using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXL.Contents.Menu_Lateral {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage {
        public Master() {
            InitializeComponent();
        }

        public void mudarPagina1(object sender, EventArgs args) {
            Detail = new NavigationPage(new Navegation.Page1());
            IsPresented = false;
        }
        public void mudarPagina2(object sender,EventArgs args) {
            Detail = new NavigationPage(new Navegation.Page2());
            IsPresented = false;
        }
        public void mudarPagina3(object sender,EventArgs args) {
            Detail = new Navegation.Modal();
            IsPresented = false;
        }
    }
}