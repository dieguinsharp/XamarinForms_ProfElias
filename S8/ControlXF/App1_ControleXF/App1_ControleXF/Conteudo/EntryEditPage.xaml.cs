using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_ControleXF.Conteudo {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryEditPage :ContentPage {
        public EntryEditPage() {
            InitializeComponent();
            txtSenha.TextChanged += delegate (object sender,TextChangedEventArgs args) {
                lblDuplicar.Text = args.NewTextValue;
            };

            txtComentario.Completed += delegate (object sender,EventArgs args) {
                lblQntdDigitos.Text = txtComentario.Text.Length.ToString();
            };
        }
    }
}