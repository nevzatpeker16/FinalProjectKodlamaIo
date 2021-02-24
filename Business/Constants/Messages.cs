using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages 
  //Sürekli new yapmamak için sabit olması için , static yazdık.
    {
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductNameInvalid = "Ürün adı kurallara uymuyor.";
        internal static string ProductListed = "Ürün Listelendi";
        internal static string CategoryListed = "Kategori Listelendi";

        public static string UnitPriceInvalid = "Hatalı Fiyat.";
        public static string updated = "Güncellendi.";
        public static string deleted = "Silindi.";

        public static string CategoryMax = "Kategori başına ürün sayısı aşıldı";
        public static string correct = "Başarılı";
        public static string eror = "Hataaa";

        public static string NameExist = "Aynı isimde ürün eklenemez";
        //Public değişkenlerin Adı büyük harfle başlar...
    }
}
