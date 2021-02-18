using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Otopark.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> List(Expression<Func<TEntity,bool>> filter=null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
    }
}
