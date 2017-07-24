using Common.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Linq.Dynamic.Core;

namespace Dao.Repository
{
    public interface IRepository
    {

    }

    public interface IRepository<TEntity,TPrimaryKey> : IRepository where TEntity : BaseEntity<TPrimaryKey>
    {
        CoreDbContext DbContext();

        /// <summary>
        /// 执行原生sql语句
        /// </summary>
        /// <param name="sql">格式化sql语句</param>
        /// <param name="parms">sql参数</param>
        /// <returns></returns>
        IQueryable<TEntity> QueryBySql(string sql, List<SqlParameter> parms);

        /// <summary>
        /// 获取数据列
        /// </summary>
        /// <param name="isTrack">是否跟踪实体</param>
        /// <returns></returns>
        List<TEntity> GetList(bool isTrack = true);

        /// <summary>
        /// 根据where条件获取数据列
        /// </summary>
        /// <param name="predicate">lambda表达式条件</param>
        /// <param name="isTrack">是否跟踪实体</param>
        /// <returns></returns>
        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, bool isTrack = true);

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
        /// 根据where条件获取数据
        /// </summary>
        /// <param name="predicate">lambda表达式条件</param>
        /// <param name="isTrack">是否跟踪实体</param>
        /// <returns></returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, bool isTrack = true);

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

        /// <summary>
        /// 根据where条件删除数据
        /// </summary>
        /// <param name="predicate">lambda表达式条件</param>
        /// <param name="autoSave">是否调用saveChanges()</param>
        void Delete(Expression<Func<TEntity, bool>> predicate, bool autoSave = true);

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="startPage">页码,起始为1</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="where">lambda表示式条件</param>
        /// <param name="order">lambda表达式条件</param>
        /// <param name="descending">是否倒序</param>
        /// <returns></returns>
        PagedResult<TEntity> GetPage(int startPage, int pageSize, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> order = null, bool descending = false);

        /// <summary>
        /// 向数据库同步更新操作
        /// </summary>
        void Save();
    }

    public interface IRepository<TEntity> : IRepository<TEntity,Int64> where TEntity : BaseEntity
    {
    }
}
