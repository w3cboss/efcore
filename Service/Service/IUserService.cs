using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Service
{
    public interface IUserService : IServiceBase<UserEntity>
    {
        /// <summary>
        /// 根据用户名获取用户实体
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        UserEntity FindByName(string name);
    }
}
