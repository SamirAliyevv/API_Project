using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiTask.core.Repositories
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);   
        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity,bool>> exp,params string[] includes);
        TEntity Get(Expression<Func<TEntity, bool>> exp, params string[] includes);
        bool isExists (Expression<Func<TEntity, bool>> exp, params string[] includes);

        void Delete(TEntity entity);

        int Commit();

    }
}
