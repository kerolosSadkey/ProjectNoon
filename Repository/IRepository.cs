using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T>
    {
        // Get all Entites => (get all customers, get all products ...etc)
        IQueryable<T> GetAll();

        // Get Entity by his ID => (get a customer by his ID)
        T GetById(int id);

        // Get all Entity's values => (get all likes of one customer, get all orders of one customer ...etc)
        IQueryable<T> GetAllByID (int id);

        // Add any Entity => (add customer, add seller ...et)
        void Add(T entity);

        // Remove an Entity => (remove a customer, remove a seller ...etc)
        void Remove(int id);

        // Update Entity info => (update Customer's Info ...etc)
        void Update(T entity);

    }
}
