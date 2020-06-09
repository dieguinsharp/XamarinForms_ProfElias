using System;
using System.Collections.Generic;
using System.Text;

namespace S8_App02.Modelos {
    public class Tarefa {
        public string nome { get; set; }
        public DateTime? dataFim { get; set; }
        public byte prioridade { get; set; }
    }
}
