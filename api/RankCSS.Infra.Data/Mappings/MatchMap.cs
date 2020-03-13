using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RankCSS.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Infra.Data.Mappings
{
    public class MatchMap : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Map).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Start).IsRequired();
            builder.Property(x => x.End).IsRequired();


            builder.HasMany(x => x.Rounds)
                .WithOne(x => x.Partida)
                .HasForeignKey(x => x.RoundID);
        }
    }
}
