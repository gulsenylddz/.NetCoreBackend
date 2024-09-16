using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete  //INTERFACE OLUŞTURDUĞUNDA PUBLIC YAPMAYI UNUTMA 
{
    public class ProductManager : IProductService //İŞ KATMANININ SOMUT SINIFI.(MANAGER)
    {

        IProductDal _iproductDal;


        public ProductManager(IProductDal productDal) {
            _iproductDal = productDal;
        }


        public List<Product> GetAllByCategoryId() //İŞ SINIFLARI BAŞKA SINIFLARI NEW'LEMEZ.
        {
            return _iproductDal.GetAll();
            //iş kodları
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _iproductDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _iproductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
           
}


    }
}
