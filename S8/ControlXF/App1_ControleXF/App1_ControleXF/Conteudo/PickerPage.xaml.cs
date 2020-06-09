using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_ControleXF.Conteudo {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerPage :ContentPage {
        public PickerPage() {
            InitializeComponent();
            Picker obj = (Picker)picker;
            obj.Items.Add("Anatel");
            obj.Items.Add("Valenet");
        }
        private void openItens(object sender, EventArgs args) {
            Picker pck = (Picker)sender;
            lblMdfItem.Text =  pck.SelectedItem.ToString() + " - " + pck.SelectedIndex.ToString();
        }
    }
}