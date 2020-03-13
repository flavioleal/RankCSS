using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using RankCSS.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Infra.Data.EF
{
    public class RankContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=rankcss;user=root;password=flavio");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PlayerMap());
            builder.ApplyConfiguration(new RoundMap());
            builder.ApplyConfiguration(new MatchMap());
            builder.ApplyConfiguration(new FileMap());
            base.OnModelCreating(builder);
        }
    }
}