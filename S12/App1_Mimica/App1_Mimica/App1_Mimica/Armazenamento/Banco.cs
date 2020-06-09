using System;
using System.Collections.Generic;
using System.Text;
using App1_Mimica.Model;

namespace App1_Mimica.Armazenamento {
    class Banco {
        public static Jogo Jogo { get; set; }
        public static short RodadaAtual { get; set; }

        public static string[][] Palavras = {
            new string [] {"Olho", "Lingua", "Chinelo", "Milho", "Penalti", "Bola", "Ping-pong"},

             new string [] {"Marceneiro", "Carpinteiro", "Azul", "Limão", "Abelha", "Macarrão"},

              new string [] {"Sisterna", "Tamanduá", "Lampada", "Lanterna", "Batman", "Superman"}
        };
    }
}
