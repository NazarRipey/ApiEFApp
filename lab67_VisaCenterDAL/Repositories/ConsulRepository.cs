using lab67_VisaCenterDAL.Entities;
using lab67_VisaCenterDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab67_VisaCenterDAL.Repositories
{
    class ConsulRepository : IRepository<Consul>
    {
        private VisaCenterContext db;

        public ConsulRepository(VisaCenterContext context)
        {
            this.db = context;
        }

        public IEnumerable<Consul> GetAll()
        {
            return db.Consuls.Include(c => c.Country);
        }

        public Consul Get(int id)
        {
            return db.Consuls.Find(id);
        }

        public void Create(Consul consul)
        {
            db.Consuls.Add(consul);
        }

        public void Update(Consul consul)
        {
            db.Entry(consul).State = EntityState.Modified;
        }

        public IEnumerable<Consul> Find(Func<Consul, Boolean> predicate)
        {
            return db.Consuls.Include(c => c.Country).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Consul consul = db.Consuls.Find(id);
            if (consul != null)
                db.Consuls.Remove(consul);
        }
    }
}
