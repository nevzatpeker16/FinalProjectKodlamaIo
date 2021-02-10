using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
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
       IDataResult<List<Product>> getAllProducts();
        IDataResult<List<Product>> getAllProductsByCategory(int categoryId);
        IDataResult<List<Product>> getAllProductsByUnitPrice(decimal unitPriceMax,decimal unitPriceMin);

        IDataResult<Product> getProductByID(int productID);
        IDataResult<List<ProductDetailDto>> GetProductDetail();

        IResult Add(Product product);

        //void dönüş tipi olmadığı için Add böyle kalacak.
    }
}

//IDataResult T olarak dönüş belirtildi. basitçe Oradaki T generic tipi fonksiyona göre List<ProductDetailDto> oldu mesela.
//IDataResult bize dönüş için data ve success ya da false gibi mesajlar vermemizi sağladı.