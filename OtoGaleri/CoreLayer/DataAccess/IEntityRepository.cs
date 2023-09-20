using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity, new()
    {//generic yapı ınterface kısmı
        T Get(int id); // bunu getbyıd de kullanacaz dışarıdan bir paremtre alıyor

        List<T> GetAll(); // bunuda get liste kullanacaz 

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);


    }
}
