using Common.Entity;
using Dao.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Service.Impl
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : BaseEntity
    {
        public abstract IRepository<TEntity> GetRepository();

        public void Delete(TEntity entity, bool autoSave = true)
        {
            this.GetRepository().Delete(entity, autoSave);
        }

        public void Delete(long id, bool autoSave = true)
        {
            this.GetRepository().Delete(id, autoSave);
        }

        public TEntity Get(long id, bool isTrack = true)
        {
            return this.GetRepository().Get(id, isTrack);
        }

        public List<TEntity> Get(List<long> ids, bool isTrack = true)
        {
            return this.GetRepository().Get(ids, isTrack);
        }

        public List<TEntity> GetList(bool isTrack = true)
        {
            return this.GetRepository().GetList(isTrack);
        }

        public TEntity Insert(TEntity entity, bool autoSave = true)
        {
            return this.GetRepository().Insert(entity, autoSave);
        }

        public void Insert(List<TEntity> entities, bool autoSave = true)
        {
            this.GetRepository().Insert(entities, autoSave);
        }

        public TEntity InsertOrUpdate(TEntity entity, bool autoSave = true)
        {
            return this.GetRepository().InsertOrUpdate(entity, autoSave);
        }

        public TEntity Update(TEntity entity, bool autoSave = true)
        {
            return this.GetRepository().Update(entity, autoSave);
        }
    }
}
