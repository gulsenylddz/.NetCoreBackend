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


        public List<Product> GetAll() //İŞ SINIFLARI BAŞKA SINIFLARI NEW'LEMEZ.
        {
            return _iproductDal.GetAll();
            //iş kodları
        }
    }
}
