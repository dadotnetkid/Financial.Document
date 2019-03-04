using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FDTS.Services
{


    public static partial class ComboBoxServices
    {
        public static List<TEntity> GetRange<TEntity>(this IQueryable<TEntity> tEntity,
            ListEditItemsRequestedByFilterConditionEventArgs args, Expression<Func<TEntity, bool>> filter = null)
        {
            var skip = args.BeginIndex;
            var take = args.EndIndex - args.BeginIndex + 1;
            var list = new List<TEntity>();

            if (filter != null)
            {
                list = tEntity.Where(filter).Skip(skip).Take(take).ToList();
            }
            else
            {
                list = tEntity.Skip(skip).Take(take).ToList();
            }




            return list;
        }

        public static TEntity GetById<TEntity>(this IQueryable<TEntity> tEntity, Expression<Func<TEntity, bool>> filter)
        {
            TEntity entity = tEntity.Where(filter).FirstOrDefault();

            return entity;
        }

        public static List<TEntity> GetObjectValue<TEntity>(this IQueryable<TEntity> tEntity,
            Expression<Func<TEntity, bool>> filter)
        {
            return tEntity.Where(filter).Take(1).ToList() ?? null;
        }
    }
}
