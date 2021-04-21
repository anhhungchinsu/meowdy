using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliverySystem.BusinessLogicLayer.BaseServices
{
    public interface IGenericRepository <TEntity> where TEntity: class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(short id);
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);

    }
}
