using AcademyEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AcademyEF.Repositories
{
    public class BaseRepository<T> where T:BaseEntity, new ()
    {
        public DbContext Context { get; set; }

        public DbSet<T> Collection { get; set; }
        
        public BaseRepository()
        {
            Context = new AcademyContext();
            Collection = Context.Set<T>();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> result = Collection;
            if (filter != null)
                return result.Where(filter).ToList();
            else
                return result.ToList();
        }

        public void Add(T item)
        {
            Collection.Add(item);
        }
        public void Edit(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }
        public void Delete(T item)
        {
            Collection.Remove(GetByID(item.ID));
            Context.SaveChanges();
        }
        public void Save(T item)
        {
            if (item.ID != 0)
                Edit(item);
            else
                Add(item);

            Context.SaveChanges();
        }
        public T GetByID(int id)
        {
            return Collection.Find(id);
        }
    }
}