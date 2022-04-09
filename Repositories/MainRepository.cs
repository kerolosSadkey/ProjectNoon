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
        DbSet<OrderSummary> OrderSummary;

        public MainRepository(IContextFactory ContextFactory)
        {
            Context = ContextFactory.GetContext();
            Table = Context.Set<T>();
            OrderSummary = Context.Set<OrderSummary>();
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

        public IQueryable<OrderSummary> getAllOrders(int id)
        {
            return OrderSummary.Where(i => i.CustomerID == id);
        }

    }
}
