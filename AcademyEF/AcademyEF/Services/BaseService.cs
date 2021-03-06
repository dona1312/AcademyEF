﻿using AcademyEF.Models;
using AcademyEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AcademyEF.Services
{
    public class BaseService<T> where T : BaseEntity, new()
    {
        protected UnitOfWork UnitOfWork;
        private readonly BaseRepository<T> baseRepo;

        public BaseService()
        {
            this.UnitOfWork = new UnitOfWork();
            baseRepo = new BaseRepository<T>(this.UnitOfWork);
        }

        public BaseService(UnitOfWork unit)
        {
            this.UnitOfWork = unit;
            baseRepo = new BaseRepository<T>(UnitOfWork);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return baseRepo.GetAll();
        }
        public void Save(T item)
        {
            try
            {
                baseRepo.Save(item);
                this.UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                this.UnitOfWork.Rollback();
            }
        }
        public T GetByID(int id)
        {
            return baseRepo.GetByID(id);
        }
        public void Delete(int id)
        {
            try
            {
                baseRepo.Delete(GetByID(id));
                this.UnitOfWork.Commit();
            }
            catch (Exception)
            {
                this.UnitOfWork.Rollback();
            }
        }
    }
}