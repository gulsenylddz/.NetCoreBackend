using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Product product)
        {
            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid); //magic strings
            }

            _iproductDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public List<Product> GetAll()
        {
            return _iproductDal.GetAll();
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

        public Product GetById(int productId)
        {
            return _iproductDal.Get(p=>p.ProductId== productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _iproductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
}

        public List<ProductDetailDto> GetProductDetails()
        {
            return _iproductDal.GetProductDetails();
        }  
    }
}
