using lab67_VisaCenterDAL.Entities;
using lab67_VisaCenterDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab67_VisaCenterDAL.Repositories
{
    class StatusRepository : IRepository<Status>
    {
        private VisaCenterContext db;

        public StatusRepository(VisaCenterContext context)
        {
            this.db = context;
        }

        public IEnumerable<Status> GetAll()
        {
            return db.Statuses;
        }

        public Status Get(int id)
        {
            return db.Statuses.Find(id);
        }

        public void Create(Status status)
        {
            db.Statuses.Add(status);
        }

        public void Update(Status status)
        {
            db.Entry(status).State = EntityState.Modified;
        }

        public IEnumerable<Status> Find(Func<Status, Boolean> predicate)
        {
            return db.Statuses.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Status status = db.Statuses.Find(id);
            if (status != null)
                db.Statuses.Remove(status);
        }
    }
}
