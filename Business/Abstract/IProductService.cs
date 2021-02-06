using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        //İş Katmanında kullanacağımız servis yapılarını burada belirtiyoruz...
        List<Product> getAllProducts();
        List<Product> getAllProductsByCategory(int categoryId);
        List<Product> getAllProductsByUnitPrice(decimal unitPriceMax,decimal unitPriceMin);

        List<ProductDetailDto> GetProductDetail();
    }
}
