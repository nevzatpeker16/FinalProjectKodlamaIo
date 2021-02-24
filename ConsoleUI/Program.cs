using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{

    //SOLİD yazılım geliştirme , 
    //o mevcuttaki koduna dokunmadan yeni yazılım geliştirme, entity framework eski kodlara ellemeden direk geçirildi.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ProductTest();
            CategoryTest();



            //Direk gerçek veritabanından data gelmiş oldu. 
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
            //foreach (var product in productManager.getAllProductsByUnitPrice(1, 5000))
            //{
            //    Console.WriteLine(product.ProductName);
            //}
            var result = productManager.GetProductDetail();
            if(result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " " + product.UnitsInStock + " " + product.CategoryName);
                }
            }

        }
        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            var result = categoryManager.GetByCategoryID(1);
            if(result.Success == true )
            {
                foreach (var category in result.Data)
                {
                    Console.WriteLine(category.CategoryName);
                }
            }    

        }
    }
}
