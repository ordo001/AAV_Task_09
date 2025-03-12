using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAV_Task_09.Models
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Sell> Sells { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Category> Categorys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=gogs.wsr.ru;Initial Catalog=Shop_Aleksandrov;User ID=587-22;Password=587-22;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Good>()
                .HasOne(g => g.Category);

            modelBuilder.Entity<Sell>()
                .HasOne(s => s.Good);
        }
    }

}
