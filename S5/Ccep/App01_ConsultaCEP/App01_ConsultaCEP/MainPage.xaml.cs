using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultaCEP.Servico;
using App01_ConsultaCEP.Servico.Modelo;

namespace App01_ConsultaCEP {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();

            btnBuscarCEP.Clicked += buscarCEP;
        }

        private void buscarCEP(object sender, EventArgs args) {

            string cep = txtCEP.Text.Trim();

            if(isValidCEP(cep)) {
                try {
                    Endereco end = viaCepService.buscarEndereco(cep);
                    
                    if (end == null) {
                        DisplayAlert("Error",("Endereço CEP não foi encontrado: " + cep + "."),"Ok");
                    } else {
                        lblResultado.Text = "Localidade:" + end.localidade + Environment.NewLine
                        + "Cep: " + end.cep + Environment.NewLine
                        + "Logradouro: " + end.logradouro + Environment.NewLine
                        + "Complemento: " + end.complemento + Environment.NewLine
                        + "Bairro: " + end.bairro + Environment.NewLine
                        + "UF: " + end.uf + Environment.NewLine
                        + "Unidade: " + end.unidade + Environment.NewLine
                        + "Ibge: " + end.ibge + Environment.NewLine
                        + "Gia: " + end.gia;
                    }                
                } catch(Exception e) {
                    DisplayAlert("Error",e.Message,"Ok");
                }
            }
        }

        private bool isValidCEP(string cep) {
            int newCEP = 0;
            if ((cep.Length == 8) && (int.TryParse(cep, out newCEP))) {
                return true;
            }else {
                DisplayAlert("Erro","Cep Inválido.","Ok");
                return false;
            }
        }
    }
}
