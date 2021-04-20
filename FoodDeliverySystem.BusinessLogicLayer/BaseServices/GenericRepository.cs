using FoodDeliverySystem.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliverySystem.BusinessLogicLayer.BaseServices
{
    public class GenericRepository<TEnity> : IGenericRepository<TEnity> where TEnity : class
    {
        protected readonly FoodDeliveryContext Context;
        private readonly DbSet<TEnity> _dbSet;

        public GenericRepository()
        {
            Context = new FoodDeliveryContext();
            _dbSet = Context.Set<TEnity>();
        }
        public bool Add(TEnity entity)
        {
            _dbSet.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(TEnity entity)
        {
            _dbSet.Remove(entity);
            return Context.SaveChanges() > 0;
        }

        public IEnumerable<TEnity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEnity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public bool Update(TEnity entity)
        {
            _dbSet.AddOrUpdate(entity);
            return Context.SaveChanges() > 0;
        }
    }
}
