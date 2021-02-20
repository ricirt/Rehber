using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RehberRise.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RehberRise.DataBase
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
        { }
        /*  public DatabaseContext(DbContextOptions<DatabaseContext> opt):base(opt)
          {

          }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DbConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
       
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
