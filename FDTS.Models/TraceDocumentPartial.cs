using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDTS.Models
{
    public partial class TraceDocuments
    {
        public int Transactions => this.TraceTransactions.Count();
        public int Discrepancies
        {

            get { return this.TraceTransactions.Sum(m => m.Discrepancies); }
        }

        //public string Source =>
        //    this.TraceTransactions.OrderByDescending(m => m.Id).FirstOrDefault()?.;
        public string DestinationDepartment =>
            this.TraceTransactions.OrderByDescending(m => m.Id).FirstOrDefault()?.ReceivingDepartment;
    }

}
