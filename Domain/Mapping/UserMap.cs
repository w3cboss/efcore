using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mapping
{
    public static class UserMap
    {
        public static void MapUser(this ModelBuilder builder)
        {
            //fluent api覆盖默认配置
            var entity = builder.Entity<UserEntity>();
            entity.ToTable("user");
            //主键
            entity.HasKey(u => u.Id);
            //建立属性到列的映射
            entity.Property<long>(u => u.Id).HasColumnName("id").UseMySQLAutoIncrementColumn("");
            entity.Property<string>(u => u.Account).HasColumnName("account").IsRequired().HasMaxLength(20);
            entity.Property<string>(u => u.Password).HasColumnName("password").IsRequired().HasMaxLength(20);
            entity.Property<string>(u => u.NickName).HasColumnName("nickname").IsRequired().HasMaxLength(20);
            entity.Property<DateTime>(u => u.CreateTime).HasColumnName("create_time").IsRequired();
            entity.Property<DateTime>(u => u.UpdateTime).HasColumnName("update_time").IsRequired();
            entity.Property<bool>(u => u.IsDeleted).HasColumnName("is_deleted").IsRequired();
        }

    }
}
