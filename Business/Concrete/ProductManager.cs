using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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
        //Product Manager new edildiğinde , bana bir adet productDal ver diyecek ve böylece productDal altında bulunan bütün operasyonlar gelir.
        //Referans injection oldu.
        public List<Product> getAllProducts()
        {

            return _productDal.GetAll();
            //Varsa İş kodları buraya yazılır.
        }

        public List<Product> getAllProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryID == categoryId);
        }

        public List<Product> getAllProductsByUnitPrice(decimal unitPriceMin, decimal unitPriceMax)
        {
            return _productDal.GetAll(p => p.UnitPrice >= unitPriceMin && p.UnitPrice <= unitPriceMax);
        }
    }
}
