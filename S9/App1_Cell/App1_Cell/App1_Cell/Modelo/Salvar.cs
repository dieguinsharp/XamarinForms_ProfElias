using System;
using System.Collections.Generic;
using System.Text;
using App1_Cell.Pagina;

namespace App1_Cell.Modelo {
    public static class Salvar {

        private static List<Funcionarios> funcionarios = new List<Funcionarios>();
        public static void salvar(Funcionarios func) {
            funcionarios.Add(func);
        }
        public static List<Funcionarios> Puxar() {
            return funcionarios;
        } 
    }
}
