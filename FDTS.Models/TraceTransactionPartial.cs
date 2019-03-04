using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDTS.Models
{
    public partial class TraceTransactions
    {
        public string ReceiveStatus => isReceived ? "Received" : "Pending";
        public string TransmitStatus => isTransmit ? "Transmitted" : "Pending";

        public int Discrepancies => this.TraceDiscrepancies.Count();


        public string LiasonName => this.Liasons?.FullName;
        public string ReceivingPersonnelName => this.ReceivingPersonnels?.FullName;
        public string ReceivingDepartment => this.Departments.DepartmentName;
    }
}
