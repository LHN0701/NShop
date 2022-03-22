using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NShop.Data.EF
{
    public class NShopDbContextFactory : IDesignTimeDbContextFactory<NShopDbContext>
    {
        public NShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("NShopDb");

            var optionsBuilder = new DbContextOptionsBuilder<NShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new NShopDbContext(optionsBuilder.Options);
        }
    }
}
