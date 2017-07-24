using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Dao.Repository;

namespace Service.Service.Impl
{
    public class UserService : ServiceBase<UserEntity>, IUserService
    {
        private readonly IUserRepository repo;

        public UserService(IUserRepository repo)
        {
            this.repo = repo;
        }

        public override IRepository<UserEntity> GetRepository()
        {
            return repo;
        }

        public UserEntity FindByName(string name)
        {
            return repo.FirstOrDefault((u) => u.NickName.Equals(name));
        }
    }
}
