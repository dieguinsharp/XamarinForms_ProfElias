using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using App1_Vagas.Modelos;
using Xamarin.Forms;

namespace App1_Vagas.Banco {
    public class AcessoBanco {
        private SQLiteConnection _conexao;

        public AcessoBanco() {
            var dep = DependencyService.Get<iCaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");

            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Vagas>();
        }

        public List<Vagas> Consultar() {
            return _conexao.Table<Vagas>().ToList();
        }
        public List<Vagas> Pesquisar(string palavra) {
            return _conexao.Table<Vagas>().Where(a => a.nomevaga.Contains(palavra)).ToList();
        }
        public void Cadastro(Vagas vaga) {
            _conexao.Insert(vaga);
        }
        public void Atualizacao(Vagas vaga) {
            _conexao.Update(vaga);
        }
        public void Exclusao(Vagas vaga) {
            _conexao.Delete(vaga);
        }
    }
}