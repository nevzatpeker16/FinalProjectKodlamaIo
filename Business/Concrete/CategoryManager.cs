using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        //Constructor Injection yapıldı burada.

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }
        public List<Category> GetByCategoryID(int categoryID)
        {
            return _categoryDal.GetAll(c => c.CategoryID == categoryID);
        }
    }
}
