
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract //İŞ KATMANI. YAPILACAK OLAN OPERASYONLARIN YAZILDIĞI KATMAN
{
    public interface IProductService
    {
        List<Product> GetAllByCategoryId(); //referans ekledik.
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetByUnitPrice(decimal min,decimal max);
    }
}
