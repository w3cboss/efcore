using Common.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public partial class UserEntity : BaseEntity
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码md5值
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
    }

    public partial class UserEntity : BaseEntity
    {
        /// <summary>
        /// 关联文章列表
        /// </summary>
        [JsonIgnore]
        public List<ArticleEntity> ArticleList { get; set; }

        public UserEntity()
        {
            ArticleList = new List<Entities.ArticleEntity>();
        }
    }
}
