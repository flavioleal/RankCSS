using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Business.Entidades
{
    public class Rodada
    {
        public int Matou { get; set; }
        public int Morreu { get; set; }
        public int? FogoAmigo { get; set; }
        public int? TiroCabeca { get; set; }
        public int? BombasPlantadas { get; set; }
        public int? BombasDefusadas { get; set; }
        public Guid JogadorID { get; set; }
        public Guid PartidaID { get; set; }
        public Jogador Jogador { get; set; }
        public Partida Partida { get; set; }
    }
}
