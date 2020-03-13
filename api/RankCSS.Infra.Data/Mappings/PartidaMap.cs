using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RankCSS.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Infra.Data.Mappings
{
    public class PartidaMap : IEntityTypeConfiguration<Partida>
    {
        public void Configure(EntityTypeBuilder<Partida> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Mapa).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Inicio).IsRequired();
            builder.Property(x => x.Fim).IsRequired();


            builder.HasMany(x => x.Rodadas)
                .WithOne(x => x.Partida)
                .HasForeignKey(x => x.PartidaID);
        }
    }
}
