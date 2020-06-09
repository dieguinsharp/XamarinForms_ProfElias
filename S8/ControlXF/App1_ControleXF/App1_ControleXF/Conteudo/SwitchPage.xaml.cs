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
    public partial class SwitchPage : ContentPage
    {
        public SwitchPage()
        {
            InitializeComponent();
        }

        private void modifySwitch(object sender, ToggledEventArgs args)
        {
            lblResultado.Text =  DateTime.Now.ToString("HH:mm") + " - " + args.Value.ToString();
        }
    }
}