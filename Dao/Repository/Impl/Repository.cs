using Common.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;

namespace Dao.Repository.Impl
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly CoreDbContext _db;

        public Repository(CoreDbContext db)
        {
            _db = db;
        }

        public CoreDbContext DbContext()
        {
            return _db;
        }

        public virtual IQueryable<TEntity> QueryBySql(string sql, List<SqlParameter> parms)
        {
            return _db.Set<TEntity>().FromSql(sql, parms);
        }

        public virtual List<TEntity> GetList(bool isTrack = true)
        {
            var ret = _db.Set<TEntity>();
            if (isTrack)
                return ret.AsNoTracking().ToList();
            else
                return ret.ToList();
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, bool isTrack = true)
        {
            var ret = _db.Set<TEntity>().Where(predicate);
            if (isTrack)
                return ret.AsNoTracking().ToList();
            else
                return ret.ToList();
        }

        public virtual TEntity Get(long id, bool isTrack = true)
        {
            var ret = _db.Set<TEntity>().Where(t => t.Id == id);
            if (isTrack)
                return ret.AsNoTracking().FirstOrDefault();
            else
                return ret.FirstOrDefault();
        }

        public virtual List<TEntity> Get(List<long> ids, bool isTrack = true)
        {
            if (ids == null || ids.Count == 0) return null;
            var ret = _db.Set<TEntity>().Where(t => ids.Contains(t.Id));
            if (isTrack)
                return ret.AsNoTracking().ToList();
            else
                return ret.ToList();
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, bool isTrack = true)
        {
            var ret = _db.Set<TEntity>().Where(predicate);
            if (isTrack)
                return ret.AsNoTracking().FirstOrDefault();
            else
                return ret.FirstOrDefault();
        }

        public virtual TEntity Insert(TEntity entity, bool autoSave = true)
        {
            _db.Set<TEntity>().Add(entity);
            if (autoSave)
                Save();
            return entity;
        }

        public virtual TEntity Update(TEntity entity, bool autoSave = true)
        {
            _db.Set<TEntity>().Update(entity);
            if (autoSave)
                Save();
            return entity;
        }

        public virtual TEntity InsertOrUpdate(TEntity entity, bool autoSave = true)
        {
            if (Get(entity.Id) == null)
                return Insert(entity);
            return Update(entity);
        }

        public virtual void Delete(TEntity entity, bool autoSave = true)
        {
            _db.Set<TEntity>().Remove(entity);
            if (autoSave)
                Save();
        }

        public virtual void Delete(long id, bool autoSave = true)
        {
            _db.Set<TEntity>().Remove(Get(id));
            if (autoSave)
                Save();
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate, bool autoSave = true)
        {
            _db.Set<TEntity>().Where(predicate).ToList().ForEach(t => Delete(t));
            if (autoSave)
                Save();
        }

        public virtual PagedResult<TEntity> GetPage(int startPage, int pageSize, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> order = null, bool descending = false)
        {
            var ret = _db.Set<TEntity>().AsQueryable().AsNoTracking();
            if (where != null)
                ret = ret.Where(where);
            if (order != null)
            {
                if (descending)
                    ret = ret.OrderByDescending(order);
                else
                    ret = ret.OrderBy(order);
            }
            else
            {
                ret = ret.OrderBy(t => t.Id);
            }
            PagedResult<TEntity> page = ret.PageResult(startPage, pageSize);
            return page;
        }

        public virtual void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Insert(List<TEntity> entities,bool autoSave = true)
        {
            _db.Set<TEntity>().AddRange(entities);
            if (autoSave)
                Save();
        }
    }
}
