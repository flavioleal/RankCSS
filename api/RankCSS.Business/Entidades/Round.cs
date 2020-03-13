using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Business.Entidades
{
    public class Round
    {
        public int Kill { get; set; }
        public int Death { get; set; }
        public int? FriendlyFire { get; set; }
        public int? HS { get; set; }
        public bool? PlantedBomb { get; set; }
        public bool? DefusedBomb { get; set; }
        public Guid PlayerID { get; set; }
        public Guid RoundID { get; set; }
        public Player Player { get; set; }
        public Match Partida { get; set; }
    }
}
