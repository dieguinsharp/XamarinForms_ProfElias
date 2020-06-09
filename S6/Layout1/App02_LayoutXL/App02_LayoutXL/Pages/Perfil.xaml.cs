using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_LayoutXL.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil :ContentPage {
        public Perfil(string idade, string data, string info, string nome) {
            InitializeComponent();
            lblInfos.Text = info;
            idadee.Text = idade;
            dataa.Text = data;
            nomee.Text = nome;
        }
    }
}