using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dao.Repository.Impl
{
    public class UserRepository : Repository<UserEntity>,IUserRepository
    {
        public UserRepository(CoreDbContext db) : base(db)
        {
        }
    }
}
