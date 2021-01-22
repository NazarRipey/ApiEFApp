using lab67_VisaCenterDAL.Entities;
using lab67_VisaCenterDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab67_VisaCenterDAL.Repositories
{
    class ManagerRepository : IRepository<Manager>
    {
        private VisaCenterContext db;

        public ManagerRepository(VisaCenterContext context)
        {
            this.db = context;
        }

        public IEnumerable<Manager> GetAll()
        {
            return db.Managers;
        }

        public Manager Get(int id)
        {
            return db.Managers.Find(id);
        }

        public void Create(Manager manager)
        {
            db.Managers.Add(manager);
        }

        public void Update(Manager manager)
        {
            db.Entry(manager).State = EntityState.Modified;
        }

        public IEnumerable<Manager> Find(Func<Manager, Boolean> predicate)
        {
            return db.Managers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Manager manager = db.Managers.Find(id);
            if (manager != null)
                db.Managers.Remove(manager);
        }
    }
}
