using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FDTS.Models.Repository;

namespace FDTS.Models.ViewModels
{
    public class DocumentAttachmentViewModel : IGenericRepository<DocumentAttachments>
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        
        public IQueryable<DocumentAttachmentViewModel> DocumentAttachments => unitOfWork.DocumentAttachmentsRepo.Fetch(includeProperties:"Departments")
            .Select(x => new DocumentAttachmentViewModel
            {
                Id = x.Id,
                Department = x.Departments,
                DocumentAttachment = x

            }).OrderByDescending(m=>m.Id);

        public DocumentAttachments DocumentAttachment { get; set; }

        public Departments Department { get; set; }

        public int Id { get; set; }

        public void Update(DocumentAttachments entity)
        {
            unitOfWork.DocumentAttachmentsRepo.Insert(entity);
            unitOfWork.Save();
        }

        public void AddNew(DocumentAttachments entity)
        {
            unitOfWork.DocumentAttachmentsRepo.Update(entity);
            unitOfWork.Save();
        }

        public void Delete(Expression<Func<DocumentAttachments, bool>> filter)
        {
            unitOfWork.DocumentAttachmentsRepo.Delete(filter);
            unitOfWork.Save();
        }
    }
}
