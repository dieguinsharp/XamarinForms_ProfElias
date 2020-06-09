using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using App1_NossoChat.Model;
using App1_NossoChat.View;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace App1_NossoChat.Services {
    class ServiceREST {

        private static string enderecoBase = "http://ws.spacedu.com.br/xf2018/rest/api";
        public async static Task<Usuario> GetUsuario(Usuario usuario) {
            var url = enderecoBase + "/usuario";

            FormUrlEncodedContent str = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("nome", usuario.nome),
                new KeyValuePair<string,string>("password", usuario.password)
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = await requisicao.PostAsync(url,str);

            if(resposta.StatusCode == HttpStatusCode.OK) {
                var conteudo = await resposta.Content.ReadAsStringAsync();
                

                return JsonConvert.DeserializeObject<Usuario>(conteudo);
            }



            return null;
        }

        public async static Task<List<Chat>> GetChat() {
            var url = enderecoBase + "/chats";
            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = await requisicao.GetAsync(url);

            if(resposta.StatusCode == HttpStatusCode.OK) {
                string conteudo = await resposta.Content.ReadAsStringAsync();
                    if(conteudo.Length > 2) {
                        List<Chat> lista = JsonConvert.DeserializeObject<List<Chat>>(conteudo);
                        return lista;
                    } else {
                        return null;
                    }
                
            }
            throw new Exception("Código de erro HTTP: " + resposta.StatusCode);

            
        }

        public async static Task<bool> InsertChat(Chat Chat) {
            var url = enderecoBase + "/chat";

            FormUrlEncodedContent str = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("nome", Chat.nome)
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = await requisicao.PostAsync(url,str);

            if(resposta.StatusCode == HttpStatusCode.OK) {
                return true;
            } else {
                return false;
            }
        }

        public static bool RenomearChat(Chat Chat) {
            var url = enderecoBase + Chat.id;

            FormUrlEncodedContent str = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("nome", Chat.nome)
            });

            HttpClient requisicao = new HttpClient();

            HttpResponseMessage resposta = requisicao.PutAsync(url,str).GetAwaiter().GetResult();

            if(resposta.StatusCode == HttpStatusCode.OK) {
                return true;
            } else {
                return false;
            }
        }

        public static bool DeleteChat(Chat Chat) {
            var url = enderecoBase + "/chat/delete/" + Chat.id;
            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.DeleteAsync(url).GetAwaiter().GetResult();

            if(resposta.StatusCode == HttpStatusCode.OK) {
                return true;
            } else {
                return false;
            }
        }

        public async static Task<List<Mensagens>> GetMensagemChat(Chat chat) {
            var url = enderecoBase + "/chat/" + chat.id + "/msg";
            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = await requisicao.GetAsync(url);

            if(resposta.StatusCode == HttpStatusCode.OK) {
                string conteudo =await resposta.Content.ReadAsStringAsync();
                if(conteudo != null) {
                    if(conteudo.Length > 2) {
                        List<Mensagens> lista = JsonConvert.DeserializeObject<List<Mensagens>>(conteudo);
                        return lista;
                    } else {
                        return null;
                    }
                }
            }
            return null;
        }

        public static bool InsertMensagem(Mensagens msg) {
            var url = enderecoBase + "/chat/" + msg.id_chat + "/msg";

            FormUrlEncodedContent str = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string,string>("mensagem", msg.mensagem),
                new KeyValuePair<string,string>("id_usuario", msg.id_usuario.ToString())
            });

            HttpClient requisicao = new HttpClient();

            HttpResponseMessage resposta = requisicao.PostAsync(url,str).GetAwaiter().GetResult();

            if(resposta.StatusCode == HttpStatusCode.OK) {
                return true;
            } else {
                return false;
            }
        }

        public static bool DeleteMensagem(Mensagens msg) {
            var url = enderecoBase + "/chat/" + msg.id_chat + "/delete/" + msg.id;

            HttpClient requisicao = new HttpClient();

            HttpResponseMessage resposta = requisicao.DeleteAsync(url).GetAwaiter().GetResult();

            if(resposta.StatusCode == HttpStatusCode.OK) {
                return true;
            } else {
                return false;
            }
        }

    }
}
