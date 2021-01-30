using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        //İş Katmanında kullanacağımız servis yapılarını burada belirtiyoruz...
        List<Product> getAllProducts();

    }
}
