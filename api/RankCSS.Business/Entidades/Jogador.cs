using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Business.Entidades
{
    public class Jogador : Entity
    {
        public string Nome { get; set; }
        public string IP { get; set; }
        public virtual List<Rodada> Rodadas { get; set; }

    }
}
