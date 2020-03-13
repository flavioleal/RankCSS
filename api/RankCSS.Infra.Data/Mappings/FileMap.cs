using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RankCSS.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Infra.Data.Mappings
{
    public class FileMap : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Processed)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.Content)
                .HasColumnType("blob")
                .IsRequired();

            builder.Property(x => x.ProcessingDate)
                .IsRequired();
        }
    }
}
