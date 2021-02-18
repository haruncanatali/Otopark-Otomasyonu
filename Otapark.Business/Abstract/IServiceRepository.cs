using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Otapark.Business.Abstract
{
    public interface IServiceRepository<TManager>
    {
        void Add(TManager entity);
        void Update(TManager entity);
        void Delete(TManager entity);
        List<TManager> List(Expression<Func<TManager, bool>> filter = null);
        TManager Get(Expression<Func<TManager, bool>> filter);
    }
}
