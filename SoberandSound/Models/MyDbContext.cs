using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SoberandSound.Models
{
    public class MyDbContext : DbContext 
    {
        public MyDbContext(string connectionString)
        {
            this.Database.Connection.ConnectionString = connectionString;
        }
        public DbSet<Lifestyle> Life { get; set; }
    }
}