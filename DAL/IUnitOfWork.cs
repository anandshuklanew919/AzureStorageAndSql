﻿using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepo { get; }
        int SaveChanges();
    }
}
