using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService

    {
        //Bu referans injection olayını çok iyi anlamak lazım , bütün yazılımda nesne bağlılığını en aza indiriyor.
        //IProductDal herşey olabilir istediği herşey memory ya da başka biri, problem yok Interface gönderiyoruz çünkü...

        IProductDal _productDal;
        ICategoryService _categoryService;
        
        
        
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
           _productDal = productDal;
            _categoryService = categoryService; 


        }
       [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //ValidationTool core den geliyor... 
            //ValidationAspect ile validation yapıldı.
           IResult result =  BusinessRules.Run(CheckIfProductCountOfCategoryMax(product), CheckProductNameExist(product),_categoryService.CheckCategoryCount());
            if(result != null)
            {
                return result;
            }
                    _productDal.Add(product);
                    return new SuccessResult(Messages.ProductAdded);
         
        }
        


        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.deleted);
        }

        //Result IResult tipinde , 


        //Product Manager new edildiğinde , bana bir adet productDal ver diyecek ve böylece productDal altında bulunan bütün operasyonlar gelir.
        //Referans injection oldu.
        public IDataResult<List<Product>> getAllProducts()
        {
            if (DateTime.Now.Hour == 21)
            {

                return new ErorDataResult<List<Product>>("Bakım zamanı");
            }
            else
            {
                return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
            }
            //Varsa İş kodları buraya yazılır.
        }

        public IDataResult<List<Product>> getAllProductsByCategory(int categoryId)

        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryID == categoryId), Messages.ProductListed);
            
        }

        public IDataResult<List<Product>> getAllProductsByUnitPrice(decimal unitPriceMin, decimal unitPriceMax)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= unitPriceMin && p.UnitPrice <= unitPriceMax), Messages.ProductListed);
            
        }

        public IDataResult<Product> getProductByID(int productID)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductID==productID),Messages.ProductListed);

            //p öyle ki p.productID  eşitse girilen productID ye .
            //Bu da productdal a gider..
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(),Messages.ProductListed);
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.updated);
        }
        private IResult CheckIfProductCountOfCategoryMax(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryID == product.CategoryID).Count;
            if (result >= 10)
            {
                return new ErorResult(Messages.CategoryMax);
            }
            else
            {
                return new SuccessResult(Messages.correct);
            }
        }
        private IResult CheckProductNameExist(Product product)
        {
            var result = _productDal.GetAll(p => p.ProductName == product.ProductName).Any();
            if(result == true)
            {
                return new ErorResult(Messages.NameExist);
            }
            else
            {
                return new SuccessResult(Messages.correct);
            }

        }
        private IResult CheckCategoryCount()
        {
            var result = _categoryService.GetAll();
         
            if (result.Data.Count < 10)
            {
                return new SuccessResult(Messages.correct);
            }
            else
            {
                return new ErorResult(Messages.eror);
            }

        }
    }

}
