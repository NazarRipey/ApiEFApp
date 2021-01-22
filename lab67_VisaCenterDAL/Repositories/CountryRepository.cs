using lab67_VisaCenterDAL.Entities;
using lab67_VisaCenterDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab67_VisaCenterDAL.Repositories
{
    class CountryRepository : IRepository<Country>
    {
        private VisaCenterContext db;

        public CountryRepository(VisaCenterContext context)
        {
            this.db = context;
        }

        public IEnumerable<Country> GetAll()
        {
            return db.Countries;
        }

        public Country Get(int id)
        {
            return db.Countries.Find(id);
        }

        public void Create(Country country)
        {
            db.Countries.Add(country);
        }

        public void Update(Country country)
        {
            db.Entry(country).State = EntityState.Modified;
        }

        public IEnumerable<Country> Find(Func<Country, Boolean> predicate)
        {
            return db.Countries.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Country country = db.Countries.Find(id);
            if (country != null)
                db.Countries.Remove(country);
        }
    }
}
