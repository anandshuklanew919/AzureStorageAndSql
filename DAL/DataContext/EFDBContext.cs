using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataContext
{
    public class EFDBContext : DbContext
    {
        public EFDBContext()
        {

        }
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("sql connection here");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ProductModel> Products { get; set; } = null!;
    }
}
