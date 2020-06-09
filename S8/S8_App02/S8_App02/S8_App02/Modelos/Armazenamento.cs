using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace S8_App02.Modelos {
    public class Armazenamento {
        private List<Tarefa> list { get; set; }

        private List<Tarefa> ListarNoProperty(){
            if(App.Current.Properties.ContainsKey("Tarefas")) {
                string desserialize = (String)App.Current.Properties["Tarefas"];              
                List<Tarefa> list = JsonConvert.DeserializeObject<List<Tarefa>>(desserialize);
                return list;
            }
            return new List<Tarefa>();
        }
        public void Deletar(int i) {
            list = listagem();
            list.RemoveAt(i);
            SalvarProperty(list);
        }
        public void Salvar (Tarefa tarefa) {
            list = listagem();
            list.Add(tarefa);
            SalvarProperty(list);    
        }
        private void SalvarProperty(List<Tarefa> list) {
            if(App.Current.Properties.ContainsKey("Tarefas")) {
                App.Current.Properties.Remove("Tarefas");
            }

            string serialize = JsonConvert.SerializeObject(list);
            App.Current.Properties.Add("Tarefas", serialize);
        }
        public void Finalizar(Tarefa tarefa,int indice) {
            list = listagem();
            list.RemoveAt(indice);
            tarefa.dataFim = DateTime.Now;
            list.Add(tarefa);
            SalvarProperty(list);
        }
        public List<Tarefa> listagem() {
            return ListarNoProperty();
        }
    }
}
