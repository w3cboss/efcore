using Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public partial class ArticleEntity : BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }

    public partial class ArticleEntity : BaseEntity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 关联用户
        /// </summary>
        public UserEntity User { get; set; }
    }
}
