using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RankCSS.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Infra.Data.Mappings
{
    public class RoundMap : IEntityTypeConfiguration<Round>
    {
        public void Configure(EntityTypeBuilder<Round> builder)
        {
            builder.HasKey(x => new { x.PlayerID, x.RoundID});

            builder.Property(x => x.Kill);
            builder.Property(x => x.Death);
            builder.Property(x => x.FriendlyFire);
            builder.Property(x => x.HS);
            builder.Property(x => x.PlantedBomb);
            builder.Property(x => x.DefusedBomb);
            
            
        }
    }
}
