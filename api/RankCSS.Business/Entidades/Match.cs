using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Business.Entidades
{
    public class Match : Entity
    {
        public string Map { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public virtual List<Round> Rounds { get; set; }

    }
}
