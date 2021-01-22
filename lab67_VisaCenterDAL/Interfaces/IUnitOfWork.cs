using lab67_VisaCenterDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab67_VisaCenterDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Case> Cases { get; }
        IRepository<Client> Clients { get; }
        IRepository<Consul> Consuls { get; }
        IRepository<Country> Countries { get; }
        IRepository<Manager> Managers { get; }
        IRepository<Status> Statuses { get; }
        void Save();
    }
}
