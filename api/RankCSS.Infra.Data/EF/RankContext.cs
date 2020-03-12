using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.Infra.Data.EF
{
    public class RankContext : DbContext
    {
        public RankContext(DbContextOptions<RankContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}