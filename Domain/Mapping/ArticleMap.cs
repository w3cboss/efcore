using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mapping
{
    public static class ArticleMap
    {
        public static void MapArticle(this ModelBuilder builder)
        {
            //fluent api覆盖默认配置
            var entity = builder.Entity<ArticleEntity>();
            entity.ToTable("article");
            //主键
            entity.HasKey(a => a.Id);
            //建立属性到列的映射
            entity.Property<long>(a => a.Id).HasColumnName("id").UseMySQLAutoIncrementColumn("");
            entity.Property<long>(a => a.UserId).HasColumnName("user_id").IsRequired();
            entity.Property<string>(a => a.Title).HasColumnName("title").HasMaxLength(20).IsRequired();
            entity.Property<string>(a => a.Content).HasColumnName("content").HasColumnType("text").IsRequired();
            entity.Property<DateTime>(a => a.CreateTime).HasColumnName("create_time").IsRequired();
            entity.Property<DateTime>(a => a.UpdateTime).HasColumnName("update_time").IsRequired();
            entity.Property<bool>(a => a.IsDeleted).HasColumnName("is_deleted").IsRequired();

            entity.HasOne(a => a.User).WithMany(u => u.ArticleList).HasForeignKey(a => a.UserId).HasConstraintName("article_fk_1").IsRequired();
        }
    }
}
