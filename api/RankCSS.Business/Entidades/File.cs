using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Business.Entidades
{
    public class File : Entity
    {
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public bool Processed { get; set; }
        public DateTime ProcessingDate { get; set; }
    }
}
