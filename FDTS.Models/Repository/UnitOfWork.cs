using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FDTS.Models;

namespace FDTS.Models.Repository
{
    public partial class UnitOfWork :IDisposable
    {

        public UnitOfWork()
        {
            
        }


        private FinancialdocumenttrackersystemEntities context = new FinancialdocumenttrackersystemEntities();

        private GenericRepository<RequestTypes> _RequestTypesRepo;
        public GenericRepository<RequestTypes> RequestTypesRepo
        {
            get
            {
                if (this._RequestTypesRepo == null)
                    this._RequestTypesRepo = new GenericRepository<RequestTypes>(context);
                return _RequestTypesRepo;
            }
            set { _RequestTypesRepo = value; }
        }


        private GenericRepository<Users> usersRepo;
        public GenericRepository<Users> UsersRepo
        {
            get
            {
                if (this.usersRepo == null)
                    this.usersRepo = new GenericRepository<Users>(context);
                return usersRepo;
            }
            set { usersRepo = value; }
        }

        private GenericRepository<UserRoles> userRolesRepo;
        public GenericRepository<UserRoles> UserRolesRepo
        {
            get
            {
                if (this.userRolesRepo == null)
                    this.userRolesRepo = new GenericRepository<UserRoles>(context);
                return userRolesRepo;
            }
            set { userRolesRepo = value; }
        }

        private GenericRepository<AddressStateProvinces> _AddressStateProvincesRepo;
        public GenericRepository<AddressStateProvinces> AddressStateProvincesRepo
        {
            get
            {
                if (this._AddressStateProvincesRepo == null)
                    this._AddressStateProvincesRepo = new GenericRepository<AddressStateProvinces>(context);
                return _AddressStateProvincesRepo;
            }
            set { _AddressStateProvincesRepo = value; }
        }

        private GenericRepository<AddressTownCities> _AddressTownCitiesRepo;
        public GenericRepository<AddressTownCities> AddressTownCitiesRepo
        {
            get
            {
                if (this._AddressTownCitiesRepo == null)
                    this._AddressTownCitiesRepo = new GenericRepository<AddressTownCities>(context);
                return _AddressTownCitiesRepo;
            }
            set { _AddressTownCitiesRepo = value; }
        }



        private GenericRepository<TraceDocuments> _TraceDocumentsRepo;
        public GenericRepository<TraceDocuments> TraceDocumentsRepo
        {
            get
            {
                if (this._TraceDocumentsRepo == null)
                    this._TraceDocumentsRepo = new GenericRepository<TraceDocuments>(context);
                return _TraceDocumentsRepo;
            }
            set { _TraceDocumentsRepo = value; }
        }

        private GenericRepository<TraceTransactions> _TraceTransactionsRepo;
        public GenericRepository<TraceTransactions> TraceTransactionsRepo
        {
            get
            {
                if (this._TraceTransactionsRepo == null)
                    this._TraceTransactionsRepo = new GenericRepository<TraceTransactions>(context);
                return _TraceTransactionsRepo;
            }
            set { _TraceTransactionsRepo = value; }
        }


        private GenericRepository<TraceDiscrepancies> _TraceDiscrepanciesRepo;
        public GenericRepository<TraceDiscrepancies> TraceDiscrepanciesRepo
        {
            get
            {
                if (this._TraceDiscrepanciesRepo == null)
                    this._TraceDiscrepanciesRepo = new GenericRepository<TraceDiscrepancies>(context);
                return _TraceDiscrepanciesRepo;
            }
            set { _TraceDiscrepanciesRepo = value; }
        }


        private GenericRepository<Departments> _DepartmentsRepo;
        public GenericRepository<Departments> DepartmentsRepo
        {
            get
            {
                if (this._DepartmentsRepo == null)
                    this._DepartmentsRepo = new GenericRepository<Departments>(context);
                return _DepartmentsRepo;
            }
            set { _DepartmentsRepo = value; }
        }

        private GenericRepository<DocumentAttachments> _DocumentAttachmentsRepo;
        public GenericRepository<DocumentAttachments> DocumentAttachmentsRepo
        {
            get
            {
                if (this._DocumentAttachmentsRepo == null)
                    this._DocumentAttachmentsRepo = new GenericRepository<DocumentAttachments>(context);
                return _DocumentAttachmentsRepo;
            }
            set { _DocumentAttachmentsRepo = value; }
        }


        private GenericRepository<DiscrepancyDescriptions> _DiscrepancyDescriptionsRepo;
        public GenericRepository<DiscrepancyDescriptions> DiscrepancyDescriptionsRepo
        {
            get
            {
                if (this._DiscrepancyDescriptionsRepo == null)
                    this._DiscrepancyDescriptionsRepo = new GenericRepository<DiscrepancyDescriptions>(context);
                return _DiscrepancyDescriptionsRepo;
            }
            set { _DiscrepancyDescriptionsRepo = value; }
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void AddNew<TEntity>(TEntity entity)
        {
        }

        public void Update<TEntity>(TEntity entity)
        {

        }

        public void Delete<TEntity>(Expression<Func<TEntity, bool>> filter)
        {

        }

    }

}