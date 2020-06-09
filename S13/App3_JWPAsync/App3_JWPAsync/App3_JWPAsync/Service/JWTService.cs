using App3_JWPAsync.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using App3_JWPAsync.Model;

namespace App3_JWPAsync.Service {
    class JWTService {
        private static string BaseURL = "http://ws.spacedu.com.br/xf2018/rest/apix";
        private static string Token;
        private static string TokenType;
        public async static Task<string> GetToken(string nome, string senha) {
            var url = BaseURL + "/token";

            HttpClient requisicao = new HttpClient();

            var parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("nome", nome),
                new KeyValuePair<string, string>("password", senha)
            });

            var resposta = await requisicao.PostAsync(url,parametros);

            if(resposta.StatusCode == HttpStatusCode.OK) {
                var respToken = JsonConvert.DeserializeObject<RespostaToken>(resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Token = respToken.access_token;
                TokenType = respToken.token_type;
                return Token;
            } else {
                return resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            
        }
        public async static Task<string> RespostaVerificar() {
            var url = BaseURL + "/verify";

            HttpClient requisicao = new HttpClient();


            requisicao.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(TokenType,Token);

            var resposta = await requisicao.GetAsync(url);

            if(resposta.StatusCode == HttpStatusCode.OK) {
                var respToken = JsonConvert.DeserializeObject<RespostaVerificar>(resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                return respToken.Usuario.nome + " " + respToken.Usuario.id;
            } else {
                return resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }
    }
}
