using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext db;

        private IProductRepository? _ProductRepo;

        public UnitOfWork(DbContext db)
        {
            this.db = db;
        }

        public IProductRepository ProductRepo
        {
            get
            {
                if (this._ProductRepo == null)
                    _ProductRepo = new ProductRepository(db);
                return _ProductRepo;
            }
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
