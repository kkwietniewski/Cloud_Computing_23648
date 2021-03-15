using Microsoft.EntityFrameworkCore;
using PeopleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleWebApp.Context
{
    public class AzureDbContext : DbContext
    {
        public AzureDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AzureDbContext()
        {
        }

        public DbSet<Person> People { get; set; }
    }
}
