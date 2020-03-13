using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RankCSS.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Infra.Data.Mappings
{
    public class RodadaMap : IEntityTypeConfiguration<Rodada>
    {
        public void Configure(EntityTypeBuilder<Rodada> builder)
        {
            builder.HasKey(x => new { x.JogadorID, x.PartidaID});

            builder.Property(x => x.Matou);
            builder.Property(x => x.Morreu);
            builder.Property(x => x.FogoAmigo);
            builder.Property(x => x.TiroCabeca);
            builder.Property(x => x.BombasPlantadas);
            builder.Property(x => x.BombasDefusadas);
            
            
        }
    }
}
