using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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

        public IDataResult<List<Category>> CheckCategoryCount()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        //Constructor Injection yapıldı burada.

        public IDataResult<List<Category>> GetAll()
        {
            return  new SuccessDataResult<List<Category>>(_categoryDal.GetAll(),Messages.CategoryListed);
        }
        public IDataResult<List<Category>> GetByCategoryID(int categoryID)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(c => c.CategoryID == categoryID),Messages.CategoryListed);
        }
        
    }
}
