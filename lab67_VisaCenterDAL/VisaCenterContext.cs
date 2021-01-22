using lab67_VisaCenterDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace lab67_VisaCenterDAL
{
    public class VisaCenterContext : DbContext
    {
        public DbSet<Case> Cases { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Consul> Consuls { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public VisaCenterContext(DbContextOptions<VisaCenterContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configuration
            modelBuilder.Entity<Case>()
                .HasOne(c => c.Client)
                .WithMany(cl => cl.Cases)
                .HasForeignKey(c => c.ClientId);

            modelBuilder.Entity<Case>()
                .HasOne(c => c.Manager)
                .WithMany(mg => mg.Cases)
                .HasForeignKey(c => c.ManagerId);

            modelBuilder.Entity<Case>()
                .HasOne(c => c.Consul)
                .WithMany(cn => cn.Cases)
                .HasForeignKey(c => c.ConsulId);

            modelBuilder.Entity<Case>()
                .HasOne(c => c.Status)
                .WithMany(s => s.Cases)
                .HasForeignKey(c => c.StatusId);

            modelBuilder.Entity<Consul>()
                .HasOne(c => c.Country)
                .WithMany(cn => cn.Consuls)
                .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<Country>()
                .HasIndex(c => c.Name).IsUnique();

            #endregion

            #region SeedIntialData
            modelBuilder.Entity<Status>()
                .HasData(
                    new Status() { Id = 1, Name = "In progress" },
                    new Status() { Id = 2, Name = "Approved" },
                    new Status() { Id = 3, Name = "Declined" }
                );

            modelBuilder.Entity<Manager>()
                .HasData(
                    new Manager() { Id = 1, Name = "Ruslana Morhun", Experience = 2 },
                    new Manager() { Id = 2, Name = "Denys Furman", Experience = 7 },
                    new Manager() { Id = 3, Name = "Olha Fasylenko", Experience = 4 }
                );

            Country us = new Country() { Id = 1, Name = "US" };
            Country uk = new Country() { Id = 2, Name = "UK" };
            Country au = new Country() { Id = 3, Name = "Australia" };

            modelBuilder.Entity<Country>()
                .HasData(us, uk, au);

            modelBuilder.Entity<Consul>()
                .HasData(
                    new Consul() { Id = 1, Name = "John Johnson", CountryId = us.Id },
                    new Consul() { Id = 2, Name = "Alice Brown", CountryId = au.Id }
                );

            modelBuilder.Entity<Client>()
                .HasData(
                    new Client() { Id = 1, Name = "Nazar Ripei", Email = "nripey1@gmail.com" },
                    new Client() { Id = 2, Name = "Dima Soroka", Email = "demetrious@gmail.com" }
                );
            #endregion
        }
    }
}
