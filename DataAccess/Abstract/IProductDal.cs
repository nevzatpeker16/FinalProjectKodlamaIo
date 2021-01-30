using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{


    //Product Tipini alabilmesi için gidip proje referansı verdik , bu sınıfa sağ tıklayıp , direk oradan project referance dedik. 
    public interface IProductDal
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        List<Product> GetAll();

        List<Product> GetByCategory(int categoryID);
    }
}
