using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2Grid.Models
{
    public class EFDataContext: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string directory = Directory.GetCurrentDirectory();
            string dir = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + directory + "\\App_Data\\NORTHWND.MDF;Integrated Security=True";
            optionsBuilder.UseSqlServer(dir);
        }
        public EFDataContext() { }
        public EFDataContext(DbContextOptions<EFDataContext> options)
           : base(options)
        {
        }
        public DbSet<Customers> customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>().ToTable("30000Records");
        }

    }
}
