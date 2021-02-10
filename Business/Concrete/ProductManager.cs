using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService

    {
        //Bu referans injection olayını çok iyi anlamak lazım , bütün yazılımda nesne bağlılığını en aza indiriyor.
        //IProductDal herşey olabilir istediği herşey memory ya da başka biri, problem yok Interface gönderiyoruz çünkü...

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
           _productDal = productDal;
        }

        public IResult Add(Product product)
        {

            if(product.ProductName.Length < 2)
            {

                //Magic Strings.
                return new ErorResult(Messages.ProductNameInvalid);

            }
            else
            {
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }
           

            //Result IResult tipinde , 
        }

        //Product Manager new edildiğinde , bana bir adet productDal ver diyecek ve böylece productDal altında bulunan bütün operasyonlar gelir.
        //Referans injection oldu.
        public IDataResult<List<Product>> getAllProducts()
        {

            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
            //Varsa İş kodları buraya yazılır.
        }

        public IDataResult<List<Product>> getAllProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryID == categoryId);
        }

        public IDataResult<List<Product>> getAllProductsByUnitPrice(decimal unitPriceMin, decimal unitPriceMax)
        {
            return _productDal.GetAll(p => p.UnitPrice >= unitPriceMin && p.UnitPrice <= unitPriceMax);
        }

        public IDataResult<Product> getProductByID(int productID)
        {
            return new DataResult<List<Product>>(_productDal.Get(p=>p.ProductID == productID),true,"Ürünler ID ye göre listelendi.");

            //p öyle ki p.productID  eşitse girilen productID ye .
            //Bu da productdal a gider..
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetail()
        {
            return _productDal.GetProductDetails();
        }
    }
}
