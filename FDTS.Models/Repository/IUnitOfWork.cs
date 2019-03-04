using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FDTS.Models.Repository
{
    public interface IGenericRepository<TEntity>:IUnitOfWork
    {
        void AddNew(TEntity entity);

        void Update(TEntity entity);
   
        void Delete(Expression<Func<TEntity, bool>> filter);


    }

    public interface IUnitOfWork
    {
    }
}
