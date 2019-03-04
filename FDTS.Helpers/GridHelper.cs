using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Linq;
using DevExpress.Web.Mvc;

namespace FDTS.Helpers
{
    public static class GridHelper
    {
        public static GridViewExtension BindToEf(this GridViewExtension gridViewExtension,
            EventHandler<LinqServerModeDataSourceSelectEventArgs> selectingMethod)
        {
            return gridViewExtension.BindToEF(string.Empty, string.Empty, selectingMethod);
        }
        public static GridViewExtension BindToEf(this GridViewExtension gridViewExtension,
          IQueryable obj)
        {
            return gridViewExtension.BindToEF(string.Empty, string.Empty, (s, e) => { e.QueryableSource = obj; });
        }
    }
}
