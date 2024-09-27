using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages // sürekli new'lememek için static kullandık.
    {
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz.";
        public static string MaintenanceTime = "Sistem Bskımda.";
        public static string ProductListed = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride 10dan fazla ürün olamaz.";
        public static string ProductNameAlreadyExists = "Bu isimde ürün zaten var";
        public static string CategoryLimitExceded = "Kategori sayısı limiti aşıldı";
        public static string CategoryAdded = "Kategori Eklendi.";
        //public static string UnitPriceInvalid = "Birim fiyat 0 veya 0'dan küçük olamaz.";
    }
}
