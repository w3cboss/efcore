using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;

namespace Service.Service
{
    public interface IServiceBase
    {
    }

    public interface IServiceBase<TEntity,TPrimaryKey> : IServiceBase where TEntity : BaseEntity
    {
        /// <summary>
        /// 获取数据列
        /// </summary>
        /// <param name="isTrack">是否跟踪实体</param>
        /// <returns></returns>
        List<TEntity> GetList(bool isTrack = true);

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id">主键 id</param>
        /// <param name="isTrack">是否跟踪实体</param>
        /// <returns></returns>
        TEntity Get(TPrimaryKey id, bool isTrack = true);

        /// <summary>
        /// 根据id列获取数据列
        /// </summary>
        /// <param name="ids">id列表</param>
        /// <param name="isTrack">是否跟踪实体</param>
        /// <returns></returns>
        List<TEntity> Get(List<TPrimaryKey> ids, bool isTrack = true);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoSave">是否调用saveChanges()</param>
        /// <returns></returns>
        TEntity Insert(TEntity entity, bool autoSave = true);

        /// <summary>
        /// 新增多条数据
        /// </summary>
        /// <param name="entities">实体列表</param>
        /// <param name="autoSave">是否调用saveChanges()</param>
        void Insert(List<TEntity> entities, bool autoSave = true);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoSave">是否调用saveChanges()</param>
        /// <returns></returns>
        TEntity Update(TEntity entity, bool autoSave = true);

        /// <summary>
        /// 新增或更新数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoSave">是否调用saveChanges()</param>
        /// <returns></returns>
        TEntity InsertOrUpdate(TEntity entity, bool autoSave = true);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="autoSave">是否调用saveChanges()</param>
        void Delete(TEntity entity, bool autoSave = true);

        /// <summary>
        /// 根据id删除数据
        /// </summary>
        /// <param name="id">主键 id</param>
        /// <param name="autoSave">是否调用saveChanges()</param>
        void Delete(TPrimaryKey id, bool autoSave = true);

    }

    public interface IServiceBase<TEntity> : IServiceBase<TEntity, long> where TEntity : BaseEntity
    {
    }
}
