﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> {

            new Product {ProductID = 1 ,CategoryID = 1 , ProductName = "Bardak" , UnitPrice = 15,UnitsInStock =35},
            new Product {ProductID = 2 ,CategoryID = 1 , ProductName = "Kamera" , UnitPrice = 2500,UnitsInStock =35},
            new Product {ProductID = 3 ,CategoryID = 2 , ProductName = "Telefon" , UnitPrice = 1750,UnitsInStock =35},
            new Product {ProductID = 4 ,CategoryID = 2 , ProductName = "Masa" , UnitPrice = 750,UnitsInStock =35},
            new Product {ProductID = 5 ,CategoryID = 2 , ProductName = "Kağıt" , UnitPrice = 5,UnitsInStock =5000}

     //Bellekte proje çalıştığında direk bize ürün listesi oluşturmuş olacak.
            };
            //Bir adet _products nesnesi ram da oluşturuldu...
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {

            _products.Add(product);
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {

            //Product productToDelete new lenirse yanlış olur burada gereksiz.
            //Burada bu foreach yerine LINQ kullanılacak.
            //Product productToDelete = null;
            //foreach (var prod in _products)
            //{
            //    if(product.ProductID == prod.ProductID)
            //    {
            //        productToDelete = prod;
            //    }

            //}
            //_products.Remove(productToDelete);

            //LINQ ile direk Product tipinde productToDelete nesnesini oluşturdu ve direk , ID ye göre product dizisinde arayıp sildik.
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductID == product.ProductID);
            //Direk foreach yaptı.
            //Lambda ile , her p için p.productId eşitse product.ProductID 
            _products.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
            //Bütün ürünlerin listesini döndürecek... 
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetByCategory(int categoryID)
        {
             return _products.Where(p => p.CategoryID == categoryID).ToList();

            //Where koşulu içindeki şarta uyan bütün elemenleri liste halinde döndürür.
            //SQL Where gibi düşünülebilir.

        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            //Direk Ürün id bazında ürünü bul diyoruz . 
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductID = product.ProductID;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
