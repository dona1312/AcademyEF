using AcademyEF.Models;
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
        private readonly BaseRepository<T> baseRepo;

        public BaseService()
        {
            baseRepo = new BaseRepository<T>();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return baseRepo.GetAll();
        }
        public void Save(T item)
        {
            baseRepo.Save(item);
        }
        public T GetByID(Guid id)
        {
            return baseRepo.GetByID(id);
        }
        public void Delete(Guid id)
        {
            baseRepo.Delete(GetByID(id));
        }
    }
}