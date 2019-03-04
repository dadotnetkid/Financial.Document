using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDTS.Models;

namespace FDTS.Helpers
{
    public class SqlDataHelper
    {
        private FinancialdocumenttrackersystemEntities db => new FinancialdocumenttrackersystemEntities();

        public void SqlBulkInsert(string tableName,DataTable dataTable)
        {
            using (SqlConnection sqlConnection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlConnection))
                {
                    sqlBulkCopy.DestinationTableName = tableName;
                    sqlBulkCopy.WriteToServer(dataTable);
                }

            }

        }
    }
}
