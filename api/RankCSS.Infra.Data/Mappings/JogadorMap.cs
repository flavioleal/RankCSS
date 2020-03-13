using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RankCSS.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Infra.Data.Mappings
{
    public class JogadorMap : IEntityTypeConfiguration<Jogador>
    {
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IP).HasMaxLength(20).IsRequired();

            builder.HasMany(x => x.Rodadas)
                .WithOne(x => x.Jogador)
                .HasForeignKey(x => x.JogadorID);
        }
    }
}
