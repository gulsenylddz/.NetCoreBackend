using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    //ÜRÜN DETAYLARININ VERİLDİĞİ SAYFA( ÜRÜNÜN DETAYLARINI GETİR GİBİ)
    public interface IProductDal : IEntityRepository<Product> //Dal=Data Access Layer 
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
