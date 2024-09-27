using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete  //INTERFACE OLUŞTURDUĞUNDA PUBLIC YAPMAYI UNUTMA 
{

    //CROSS CUTTING CONCERNS:LOG-CACHE-TRANSACTION-AUTHORIZATION...
    public class ProductManager : IProductService //İŞ KATMANININ SOMUT SINIFI.(MANAGER)
    {

        IProductDal iproductDal;
        public ProductManager(IProductDal productDal)
        {
            iproductDal = productDal;
        }


        [ValidationAspect(typeof(ProductValidator))]

        public IResult Add(Product product)
        {
            //business codes 

            iproductDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            var result = new SuccessDataResult<List<Product>>(iproductDal.GetAll(), Messages.ProductListed);
            return result;

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
