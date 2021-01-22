using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace lab67_VisaCenterDAL
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<VisaCenterContext>
    {
        public VisaCenterContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VisaCenterContext>();

            // получаем конфигурацию из файла appsettings.json
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("D:\\Labs5\\kpz\\lab67_VisaCenterAPI\\lab67_VisaCenterAPI\\appsettings.json");
            IConfigurationRoot config = builder.Build();

            // получаем строку подключения из файла appsettings.json
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new VisaCenterContext(optionsBuilder.Options);
        }
    }
}
