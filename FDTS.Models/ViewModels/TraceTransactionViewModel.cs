using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDTS.Models.Repository;

namespace FDTS.Models.ViewModels
{
    public partial class TraceTransactionViewModel
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public IQueryable<TraceTransactionViewModel> TraceTransactions =>

        unitOfWork.TraceTransactionsRepo.Fetch().Select(x => new TraceTransactionViewModel
        {
            Id=x.Id,
            TraceTransaction = x,
            Liason = x.Liasons,
            LiasonName = x.Liasons.FirstName + " " + x.Liasons.LastName,
            ReceivingPersonnel = x.ReceivingPersonnels,
            ReceivingPersonnelName = x.ReceivingPersonnels.FirstName + " " + x.ReceivingPersonnels.LastName,
        });

       
    }

    public partial class TraceTransactionViewModel
    {
        public int Id { get; set; }
        public TraceTransactions TraceTransaction { get; set; }
        public Users Liason { get; set; }
        public string LiasonName { get; set; }
        public Users ReceivingPersonnel { get; set; }
        public string ReceivingPersonnelName { get; set; }
    }
}
