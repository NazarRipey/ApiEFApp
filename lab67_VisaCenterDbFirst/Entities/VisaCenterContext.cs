using Microsoft.EntityFrameworkCore;

#nullable disable

namespace lab67_VisaCenterAPI.Entities
{
    public partial class VisaCenterContext : DbContext
    {
        public VisaCenterContext()
        {
        }

        public VisaCenterContext(DbContextOptions<VisaCenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<CompoundInfo> CompoundInfos { get; set; }
        public virtual DbSet<Consul> Consuls { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<FiredManager> FiredManagers { get; set; }
        public virtual DbSet<FullInfoView> FullInfoViews { get; set; }
        public virtual DbSet<FullServiceInfoView> FullServiceInfoViews { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Secretary> Secretaries { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<ViewClientInfo> ViewClientInfos { get; set; }
        public virtual DbSet<ViewClientInfoBasedOnRole> ViewClientInfoBasedOnRoles { get; set; }
        public virtual DbSet<VisaManager> VisaManagers { get; set; }
        public virtual DbSet<VisaType> VisaTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=WIN-7GHLMJ72709\\MSSQLSERVER01;Database=VisaCenter;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Case>(entity =>
            {
                entity.Property(e => e.CaseId).HasColumnName("caseId");

                entity.Property(e => e.CaseFinishDate)
                    .HasColumnType("date")
                    .HasColumnName("caseFinishDate");

                entity.Property(e => e.CaseStartDate)
                    .HasColumnType("date")
                    .HasColumnName("caseStartDate");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.ConsulId).HasColumnName("consulId");

                entity.Property(e => e.ManagerId).HasColumnName("managerId");

                entity.Property(e => e.ServiceId).HasColumnName("serviceId");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cases_Clients");

                entity.HasOne(d => d.Consul)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.ConsulId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cases_Consuls");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Cases_VisaManagers");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cases_Services");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cases_Status");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(e => e.Email, "NCLIX_Clients_Email");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<CompoundInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CompoundInfo");

                entity.Property(e => e.CaseStartDate)
                    .HasColumnType("date")
                    .HasColumnName("case_start_date");

                entity.Property(e => e.ClientEmail)
                    .HasMaxLength(50)
                    .HasColumnName("client_email");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(50)
                    .HasColumnName("client_name");

                entity.Property(e => e.CounsulName)
                    .HasMaxLength(50)
                    .HasColumnName("counsul_name");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(50)
                    .HasColumnName("country_name");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .HasColumnName("status_name");

                entity.Property(e => e.VisaManagerExperience).HasColumnName("visaManager_experience");

                entity.Property(e => e.VisaManagerName)
                    .HasMaxLength(50)
                    .HasColumnName("visa_manager_name");

                entity.Property(e => e.VisaTypeName)
                    .HasMaxLength(50)
                    .HasColumnName("visa_type_name");
            });

            modelBuilder.Entity<Consul>(entity =>
            {
                entity.HasIndex(e => e.CountryId, "NCLIX_Consuls_CountryId");

                entity.Property(e => e.ConsulId).HasColumnName("consulId");

                entity.Property(e => e.CountryId).HasColumnName("countryId");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Consuls)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Consuls_Countries");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).HasColumnName("countryId");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PriceCoef)
                    .HasColumnType("decimal(5, 3)")
                    .HasColumnName("priceCoef");
            });

            modelBuilder.Entity<FiredManager>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FireDate)
                    .HasColumnType("date")
                    .HasColumnName("fireDate");

                entity.Property(e => e.ManagerId).HasColumnName("managerId");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<FullInfoView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("FullInfoView");

                entity.Property(e => e.CaseFinishDate)
                    .HasColumnType("date")
                    .HasColumnName("caseFinishDate");

                entity.Property(e => e.CaseStartDate)
                    .HasColumnType("date")
                    .HasColumnName("caseStartDate");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("client_name");

                entity.Property(e => e.ConsulName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("consul_name");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("country_name");

                entity.Property(e => e.ManagerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("manager_name");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.VisaTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("visaType_name");
            });

            modelBuilder.Entity<FullServiceInfoView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("FullServiceInfoView");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.VisaType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("visa_type");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("reviewId");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.ManagerId).HasColumnName("managerId");

                entity.Property(e => e.Review1)
                    .HasColumnType("text")
                    .HasColumnName("review");

                entity.Property(e => e.ReviewDate)
                    .HasColumnType("date")
                    .HasColumnName("reviewDate");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_Clients");
            });

            modelBuilder.Entity<Secretary>(entity =>
            {
                entity.Property(e => e.SecretaryId).HasColumnName("secretaryId");

                entity.Property(e => e.ConsulId).HasColumnName("consulId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.Consul)
                    .WithMany(p => p.Secretaries)
                    .HasForeignKey(d => d.ConsulId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Secretaries_Consuls");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasIndex(e => new { e.VisaTypeId, e.CountryId }, "UQ__Services__33643B21B5E5B271")
                    .IsUnique();

                entity.Property(e => e.ServiceId).HasColumnName("serviceId");

                entity.Property(e => e.CountryId).HasColumnName("countryId");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.VisaTypeId).HasColumnName("visaTypeId");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_Countries");

                entity.HasOne(d => d.VisaType)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.VisaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_VisaTypes");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ViewClientInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewClientInfo");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ViewClientInfoBasedOnRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewClientInfoBasedOnRole");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<VisaManager>(entity =>
            {
                entity.HasKey(e => e.ManagerId);

                entity.HasIndex(e => e.Experience, "NCLIX_VisaManagers_Experience");

                entity.Property(e => e.ManagerId).HasColumnName("managerId");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .HasColumnName("position");

                entity.Property(e => e.Rating)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("rating");
            });

            modelBuilder.Entity<VisaType>(entity =>
            {
                entity.Property(e => e.VisaTypeId).HasColumnName("visaTypeId");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
