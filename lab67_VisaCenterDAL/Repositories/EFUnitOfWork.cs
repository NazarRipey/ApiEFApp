using lab67_VisaCenterDAL.Entities;
using lab67_VisaCenterDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace lab67_VisaCenterDAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private VisaCenterContext db;

        private CaseRepository caseRepository;
        private ClientRepository clientRepository;
        private ConsulRepository consulRepository;
        private CountryRepository countryRepository;
        private ManagerRepository managerRepository;
        private StatusRepository statusRepository;
        public EFUnitOfWork(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VisaCenterContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            db = new VisaCenterContext(options);
        }

        public IRepository<Case> Cases
        {
            get
            {
                if (caseRepository == null)
                    caseRepository = new CaseRepository(db);
                return caseRepository;
            }
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(db);
                return clientRepository;
            }
        }

        public IRepository<Consul> Consuls
        {
            get
            {
                if (consulRepository == null)
                    consulRepository = new ConsulRepository(db);
                return consulRepository;
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                if (countryRepository == null)
                    countryRepository = new CountryRepository(db);
                return countryRepository;
            }
        }

        public IRepository<Manager> Managers
        {
            get
            {
                if (managerRepository == null)
                    managerRepository = new ManagerRepository(db);
                return managerRepository;
            }
        }

        public IRepository<Status> Statuses
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new StatusRepository(db);
                return statusRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
