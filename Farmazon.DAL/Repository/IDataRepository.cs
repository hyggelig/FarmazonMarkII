using System;
using System.Collections.Generic;
using System.Text;

namespace Farmazon.DAL.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetUsersProducts(long ownerId, string ownerName, string ownerLastName);
        TEntity Get(long id);
        void Create(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
