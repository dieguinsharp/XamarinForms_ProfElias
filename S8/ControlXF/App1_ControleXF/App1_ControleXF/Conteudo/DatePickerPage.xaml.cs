using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_ControleXF.Conteudo {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatePickerPage :ContentPage {
        public DatePickerPage() {
            InitializeComponent();
        }
        private void ActionDateSelected(object sender, DateChangedEventArgs args) {
            lblResultado.Text = args.NewDate.ToString("dd/MM/yyyy") + " > " + args.OldDate.ToString("dd/MM/yyyy");
        }
    }
}