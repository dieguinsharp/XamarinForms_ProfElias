using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App1_Vagas.Banco;
using Foundation;
using UIKit;
using Xamarin.Forms;
using System.IO;

[assembly:Dependency(typeof(App1_Vagas.Banco.AcessoBanco))]
namespace App1_Vagas.iOS.Banco {
    public class CaminhoIOS:iCaminho {
        public string ObterCaminho(string NomeArquivoBanco) {
            string caminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string caminhoBiblioteca = Path.Combine(caminhoDaPasta,"..","Library");
            string caminhoBanco = Path.Combine(caminhoBiblioteca,NomeArquivoBanco);
            return caminhoBanco;
        }
    }
}
   

   
