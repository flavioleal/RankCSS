using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Business.Entidades
{
    public class Player : Entity
    {
        public string Nickname { get; set; }
        public string IP { get; set; }
        public virtual List<Round> Rounds { get; set; }

    }
}
