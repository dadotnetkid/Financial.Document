using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FDTS.Models.Repository;

namespace FDTS.Models.ViewModels
{
    public class DiscrepancyDescriptionViewModel : IGenericRepository<DiscrepancyDescriptions>
    {
        public IQueryable<DiscrepancyDescriptionViewModel> DiscrepancyDescriptions =>
            unitOfWork.DiscrepancyDescriptionsRepo.Fetch().Select(x => new DiscrepancyDescriptionViewModel
            {
                Department = x.Departments,
                DiscrepancyDescription = x,
                Id = x.Id
            });

        public IQueryable<Departments> Departments => unitOfWork.DepartmentsRepo.Fetch();



        public int Id { get; set; }

        public DiscrepancyDescriptions DiscrepancyDescription { get; set; }

        public Departments Department { get; set; }


        private UnitOfWork unitOfWork = new UnitOfWork();
        public void Update(DiscrepancyDescriptions entity)
        {
            unitOfWork.DiscrepancyDescriptionsRepo.Update(entity);
            unitOfWork.Save();
        }

        public void AddNew(DiscrepancyDescriptions entity)
        {
            unitOfWork.DiscrepancyDescriptionsRepo.Insert(entity);
            unitOfWork.Save();
        }

        public void Delete(Expression<Func<DiscrepancyDescriptions, bool>> filter)
        {
            unitOfWork.DiscrepancyDescriptionsRepo.Delete(filter);
            unitOfWork.Save();
        }
    }
}
