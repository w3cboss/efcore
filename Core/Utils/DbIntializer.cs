using Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Utils
{
    public class DbInitializer
    {
        public static void Initialize(CoreDbContext context)
        {
            //确保数据库已创建
            context.Database.EnsureCreated();
        }
    }
}
