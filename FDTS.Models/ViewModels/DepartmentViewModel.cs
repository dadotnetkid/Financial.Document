using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FDTS.Models.Repository;

namespace FDTS.Models.ViewModels
{
    public class DepartmentViewModel : IGenericRepository<Departments>
    {
        public UnitOfWork unitOfWork = new UnitOfWork();
        public IQueryable<Departments> Departments => unitOfWork.DepartmentsRepo.Fetch();
        public void Update(Departments entity)
        {
            unitOfWork.DepartmentsRepo.Insert(entity);
            unitOfWork.Save();
        }

        public void AddNew(Departments entity)
        {
            unitOfWork.DepartmentsRepo.Update(entity);
            unitOfWork.Save();
        }

        public void Delete(Expression<Func<Departments, bool>> filter)
        {
            unitOfWork.DepartmentsRepo.Delete(filter);
            unitOfWork.Save();
        }
    }


}
