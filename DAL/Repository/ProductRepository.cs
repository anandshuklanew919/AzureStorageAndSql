using DAL.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class ProductRepository : Repository<ProductModel>, IProductRepository
    {
        public ProductRepository(DbContext db)
        {
            this.db = db;
        }
    }
}
