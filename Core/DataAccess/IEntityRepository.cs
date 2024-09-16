
using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess  //CORE KATMANI DİĞER KATMANLARI REFERANS ALMAZ
{
    public interface IEntityRepository <T> where T:class,IEntity,new()
    // GENERICS YAPIP KULLANMAK İÇİN OLUŞTURDUĞUMUZ INTERFACE.
    {
        List<T> GetAll(Expression<Func<T,bool>>  filter = null); //(LINQ) FİLTRELEME YAPMAK İÇİN EXPRESSION İFADESİ KULLANDIK

        T Get(Expression<Func<T, bool>> filter = null); // FİLTRE DE VERMEYEBİLİRSİN.

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        // T:class,IEntity --> T YA ENTITY OLABILIR YA DA ENTITYDEN IMPLEMENTE EDİLEN BİR ŞEY OLABİLİR ANLAMINA GELİR


    }
}
