using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultaCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultaCEP.Servico.Modelo {
    public class viaCepService {

        public static Endereco buscarEndereco(string cep) {
            string newEnderecoURL = string.Format("https://viacep.com.br/ws/" + cep + "/json/");
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(newEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if(end.cep == null) {
                return null;
            }
            return end;
        }
    }
}
