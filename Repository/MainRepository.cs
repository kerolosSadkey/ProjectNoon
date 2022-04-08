using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MainRepository<T> : IRepository<T> where T : Base
    {
        DbContext Context;
        DbSet<T> Table;

        public MainRepository(IContextFactory ContextFactory)
        {
            Context = ContextFactory.GetContext();
            Table = Context.Set<T>();
        }

        public void Add(T entity)
        {
            Table.Add(entity);
        }

        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public IQueryable<T> GetAllByID(int id)
        {
            return Table.Where(i => i.id == id);
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public void Remove(int id)
        {
            Table.Remove(GetById(id));
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
