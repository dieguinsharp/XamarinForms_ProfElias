using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1_Vagas.Modelos {
    [Table("Vagas")]
    public class Vagas {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nomevaga { get; set; }
        public short qntdvagas { get; set; }
        public string empresa { get; set; }
        public string cidade { get; set; }
        public double salario { get; set; }
        public string descricao { get; set; }
        public string tipocontratacao { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
    }
}
