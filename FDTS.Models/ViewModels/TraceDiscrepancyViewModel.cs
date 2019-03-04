using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDTS.Models.Repository;

namespace FDTS.Models.ViewModels
{
    
    public partial class TraceDiscrepancyViewModel
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public IQueryable<TraceDiscrepancyViewModel> TraceDiscrepancies => unitOfWork.TraceDiscrepanciesRepo.Fetch().Select(x=> new TraceDiscrepancyViewModel
        {
            TraceDiscrepancy=x,
            Id=x.Id,
            TraceTransactions=x.TraceTransactions,
            DocumentAttachments=x.DocumentAttachments,
            DiscrepancyDescriptions=x.DiscrepancyDescriptions,
            
        });

        public DiscrepancyDescriptions DiscrepancyDescriptions { get; set; }

        public DocumentAttachments DocumentAttachments { get; set; }

        public TraceTransactions TraceTransactions { get; set; }

        public TraceDiscrepancies TraceDiscrepancy { get; set; }

        public int Id { get; set; }
    }
}
