using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Concrete  //INTERFACE OLUŞTURDUĞUNDA PUBLIC YAPMAYI UNUTMA 
{
    public class ProductManager : IProductService //İŞ KATMANININ SOMUT SINIFI.(MANAGER)
    {

        IProductDal iproductDal;
        public ProductManager(IProductDal productDal)
        {
            iproductDal = productDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid); //magic strings
            }

            iproductDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 11)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}

            //return new SuccessDataResult<List<Product>>(iproductDal.GetAll(), Messages.ProductListed);

            return new ErrorDataResult<List<Product>>()
            {
                Message = Messages.ProductAddeds
            };
        }

        public List<Product> GetAllByCategoryId() //İŞ SINIFLARI BAŞKA SINIFLARI NEW'LEMEZ.
        {
            return iproductDal.GetAll();
            //iş kodları
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(iproductDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(iproductDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(iproductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(iproductDal.GetProductDetails());
        }

        IDataResult<List<Product>> IProductService.GetAllByCategoryId()
        {
            throw new NotImplementedException();
        }
    }
}
