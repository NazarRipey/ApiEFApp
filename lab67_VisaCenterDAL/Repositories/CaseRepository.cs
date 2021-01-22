using lab67_VisaCenterDAL.Entities;
using lab67_VisaCenterDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab67_VisaCenterDAL.Repositories
{
    class CaseRepository : IRepository<Case>
    {
        private VisaCenterContext db;

        public CaseRepository(VisaCenterContext context)
        {
            this.db = context;
        }

        public IEnumerable<Case> GetAll()
        {
            return db.Cases
                .Include(c => c.Client)
                .Include(c => c.Consul)
                .Include(c => c.Manager)
                .Include(c => c.Status);
        }

        public Case Get(int id)
        {
            return db.Cases.Find(id);
        }

        public void Create(Case myCase)
        {
            db.Cases.Add(myCase);
        }

        public void Update(Case myCase)
        {
            db.Entry(myCase).State = EntityState.Modified;
        }

        public IEnumerable<Case> Find(Func<Case, Boolean> predicate)
        {
            return db.Cases
                .Include(c => c.Client)
                .Include(c => c.Consul)
                .Include(c => c.Manager)
                .Include(c => c.Status)
                .Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Case myCase = db.Cases.Find(id);
            if (myCase != null)
                db.Cases.Remove(myCase);
        }
    }
}
