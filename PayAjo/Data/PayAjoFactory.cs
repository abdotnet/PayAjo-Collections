using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data
{
    public class PayAjoContextFactory : IDesignTimeDbContextFactory<PayAjoContext>
    {
        public PayAjoContext CreateDbContext(string[] args)
        {
            //FileConfigurationExtensions
            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            var builder = new DbContextOptionsBuilder<PayAjoContext>();
            var connectionString = configuration.GetConnectionString("conString");
            builder.UseSqlServer(connectionString, opt => opt.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));

            return new PayAjoContext(builder.Options);
        }
    }
}
