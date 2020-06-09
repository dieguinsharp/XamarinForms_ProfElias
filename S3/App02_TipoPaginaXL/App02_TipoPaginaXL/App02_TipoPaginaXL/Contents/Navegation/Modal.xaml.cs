﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXL.Contents.Navegation {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Modal :ContentPage {
        public Modal() {
            InitializeComponent();
        }

        private void FecharModal(object sender,EventArgs args) {
            Navigation.PopModalAsync();
        }
    }
}