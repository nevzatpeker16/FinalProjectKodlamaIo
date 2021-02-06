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
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.getAllProductsByUnitPrice(1, 5000))
            {
                Console.WriteLine(product.ProductName);
            }
        }
        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
                foreach (var category in categoryManager.GetByCategoryID(1))
            {
                Console.WriteLine(category.CategoryName);

            }

        }
    }
}
