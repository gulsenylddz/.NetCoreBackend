using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal

    {

        List<Product> _products;  //GLOBAL DEĞİŞKEN OLDUĞU İÇİN _ İLE İSİMLENDİRME ÖNERİLİR.


        public InMemoryProductDal() //CTOR TAB TAB CONSRUCTOR YAPMA KISAYOLU
        {
            _products = new List<Product> {
            new Product{ProductId =1,CategoryId=1,ProductName="Bottle",UnitPrice=20,UnitsInStock=25}, 
            new Product{ProductId =2,CategoryId=1,ProductName="Camera",UnitPrice=60,UnitsInStock=20}, 
            new Product{ProductId =3,CategoryId=2,ProductName="Phone",UnitPrice=2500,UnitsInStock=5}, 
            new Product{ProductId =4,CategoryId=2,ProductName="Keyboard",UnitPrice=250,UnitsInStock=4},
            new Product{ProductId =5,CategoryId=2,ProductName="Mouse",UnitPrice=85,UnitsInStock=1}, 
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // BURADA REMOVE KOMUTU KULLANILMAZ ÇÜNKÜ LİSTEDEKİ ELEMNALARIN REFERANSLAR FARKLI
            // LINQ SORGU KULLANILIR. FOR EACH İLE ÜRÜNLERİ TEK TEK DOLANMAKTAN KURTARIR
            // p=> : LAMBDA 

            Product productToDelete;
                                 
            productToDelete = _products.SingleOrDefault(p => p.ProductId==product.ProductId); //KOMUTU KULLANMAK İÇİN SYSTEM.LINQ EKLENİR.
            
        }

        public List<Product> GetAll()
        {
            return _products; //LİSTELEME İÇİN 
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;

        }
        public List<Product> GetAllByProducts(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}

