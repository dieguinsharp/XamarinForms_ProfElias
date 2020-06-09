﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Cell.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Cell.Pagina.Detalhe {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage:ContentPage {
        public DetailPage(Funcionarios funcionario) {
            InitializeComponent();

            txtNome.Text = funcionario.nome;
        }
    }
}