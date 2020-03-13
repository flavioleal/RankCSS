using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RankCSS.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Infra.Data.Mappings
{
    public class PlayerMap : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Nickname).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IP).HasMaxLength(20).IsRequired();

            builder.HasMany(x => x.Rounds)
                .WithOne(x => x.Player)
                .HasForeignKey(x => x.PlayerID);
        }
    }
}
