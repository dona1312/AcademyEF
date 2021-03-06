﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AcademyEF.Repositories
{
    public class UnitOfWork : IDisposable
    {
        DbContextTransaction transaction;
        public DbContext Context { get; private set; }

        public UnitOfWork()
        {
            this.Context = new AcademyContext();
            transaction = this.Context.Database.BeginTransaction();
        }


        public void Commit()
        {
            if (transaction != null)
            {
                transaction.Commit();
            }
            else
            {
                Dispose();
            }

        }
        public void Rollback()
        {
            if (transaction != null)
            {
                transaction.Rollback();
            }
            else
            {
                Dispose();
            }

        }
        public void Dispose()
        {
            transaction.Dispose();
            this.Context.Dispose();
        }
    }
}