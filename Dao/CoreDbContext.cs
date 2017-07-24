using Domain.Entities;
using Domain.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dao
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<ArticleEntity> Article { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.MapUser();
            builder.MapArticle();
            base.OnModelCreating(builder);
        }
    }
}
