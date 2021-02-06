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
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.getAllProductsByUnitPrice(1,5000))
            {
                Console.WriteLine(product.ProductName);
            }

            

            //Direk gerçek veritabanından data gelmiş oldu. 
        }
    }
}
