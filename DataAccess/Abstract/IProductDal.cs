using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //ÜRÜN DETAYLARININ VERİLDİĞİ SAYFA( ÜRÜNÜN DETAYLARINI GETİR GİBİ)
    public interface IProductDal : IEntityRepository<Product> //Dal=Data Access Layer 
    {
        
    }
}
