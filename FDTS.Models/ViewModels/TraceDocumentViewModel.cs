using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FDTS.Models.Repository;
using Microsoft.AspNet.Identity;

namespace FDTS.Models.ViewModels
{
    public partial class TraceDocumentViewModel : IGenericRepository<TraceDocuments>
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public IQueryable<object> TraceDocuments => unitOfWork.TraceDocumentsRepo.Fetch().Select(x => new
        {
            FullName = x.CreatedBy.FirstName + " " + x.CreatedBy.LastName,
            Id = x.Id,
            DateCreated = x.DateCreated,
            Barcode = x.Barcode
        }).OrderByDescending(x => x.Id);
        /*
         * isBudget = x.isBudget,
            isAccounting = x.isAccounting,
            isGO = x.isGO,
            isPA = x.isPA,
            isTreasury = x.isTreasury,
            isForAccountingFinalization = x.isForAccountingFinalization,
            isDone = x.isDone,
            TraceTransactions = x.TraceTransactions,
            Office = x.isBudget == null || x.isBudget == false ? "Budget Office" : x.isAccounting == null || x.isAccounting == false ? "Accounting Office" : x.isTreasury == null || x.isTreasury == false ? "Treasury" : x.isForAccountingFinalization == null || x.isForAccountingFinalization == false ? "For Accounting Finalization" : "Done"

         */

        /*
         * isBudget = x.isBudget,
           isAccounting = x.isAccounting,
           isGO = x.isGO,
           isPA = x.isPA,
           isTreasury = x.isTreasury,
           isForAccountingFinalization = x.isForAccountingFinalization,
           isDone = x.isDone,
           TraceTransactions = x.TraceTransactions,
           Office = x.isBudget == null || x.isBudget == false ? "Budget Office" : x.isAccounting == null || x.isAccounting == false ? "Accounting Office" : x.isTreasury == null || x.isTreasury == false ? "Treasury" : x.isForAccountingFinalization == null || x.isForAccountingFinalization == false ? "For Accounting Finalization" : "Done"
         */
        public IQueryable GetTraceDocuments()
        {
            var model = unitOfWork.TraceDocumentsRepo.Fetch().Select(x => new
            {
                FullName = x.CreatedBy.FirstName + " " + x.CreatedBy.LastName,
                Id = x.Id,
                DateCreated = x.DateCreated,

            });



            return TraceDocuments;
        }




        public void AddNew(TraceDocuments entity)
        {
            entity.CreatedById = HttpContext.Current.User.Identity.GetUserId();
            entity.DateCreated = DateTime.Now;
            unitOfWork.TraceDocumentsRepo.Insert(entity);
            unitOfWork.Save();
        }

        public void Update(TraceDocuments entity)
        {
            unitOfWork.TraceDocumentsRepo.Update(entity);
            unitOfWork.Save();

        }

        public void Delete(Expression<Func<TraceDocuments, bool>> filter)
        {
            unitOfWork.TraceDocumentsRepo.Delete(filter);
            unitOfWork.Save();
        }




    }

    public class TraceDocument
    {
        public string FullName { get; set; }
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? isBudget { get; set; }
        public bool? isAccounting { get; set; }
        public bool? isGO { get; set; }
        public bool? isPA { get; set; }
        public bool? isTreasury { get; set; }
        public bool? isForAccountingFinalization { get; set; }
        public bool? isDone { get; set; }
        public ICollection<TraceTransactions> TraceTransactions { get; set; }
        public string Office { get; set; }
    }
}
