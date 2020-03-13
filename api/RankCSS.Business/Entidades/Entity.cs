using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Business.Entidades
{
    public abstract class Entity
    {
        public Entity()
        {
            ID = new Guid();
        }
        public Guid ID { get; protected set; }
    }
}