using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> // GENERICS YAPIP KULLANMAK İÇİN OLUŞTURDUĞUMUZ INTERFACE.
    {
        List<T> GetAll(Expression<Func<T,bool>>  filter = null); //(LINQ) FİLTRELEME YAPMAK İÇİN EXPRESSION İFADESİ KULLANDIK

        T Get(Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);


        List<T> GetAllByCategory(int categoryId);
    }
}
