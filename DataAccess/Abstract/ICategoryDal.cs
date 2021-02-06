using Core.DataAcess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICategoryDal:IEntityRepository<Category>
        //Sen kategori için bir IEntitiyRepositorysin !!
    {
        //void AddProduct(Category category);
        //void DeleteProduct(Category category);
        //void UpdateProduct(Category category);
        //List<Category> GetAll();

        //List<Category> GetByCategory(string categoryName);
    }
}
