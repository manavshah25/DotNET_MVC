using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo_Project_MVC.Models
{
    public class AppDBContext : IdentityDbContext
    {
       
        public AppDBContext(DbContextOptions<AppDBContext> options) :base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Bought> Boughts { get; set; }

        public DbSet<Sold> Solds { get; set; }

    }
}
