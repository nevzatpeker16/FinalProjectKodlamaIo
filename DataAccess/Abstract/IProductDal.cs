using Core.DataAcess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{


    //Product Tipini alabilmesi için gidip proje referansı verdik , bu sınıfa sağ tıklayıp , direk oradan project referance dedik. 
    public interface IProductDal:IEntityRepository<Product> //Sen bir IEntitiyRepositorysin ve Product için varsın.
    {

        //Böylece bu kodlara gerek kalmadı....
        //void AddProduct(Product product);
        //void DeleteProduct(Product product);
        //void UpdateProduct(Product product);
        //List<Product> GetAll();

        //List<Product> GetByCategory(int categoryID);
    }
}

//Code Refactoring...
