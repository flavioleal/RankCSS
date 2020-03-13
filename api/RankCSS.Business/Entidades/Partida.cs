using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Business.Entidades
{
    public class Partida : Entity
    {
        public string Mapa { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public virtual List<Rodada> Rodadas { get; set; }

    }
}
