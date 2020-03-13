using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Business.Entidades
{
    public class Arquivo : Entity
    {
        public string Nome { get; set; }
        public byte[] Conteudo { get; set; }
        public bool Processado { get; set; }
        public DateTime DataProcessamento { get; set; }
    }
}
