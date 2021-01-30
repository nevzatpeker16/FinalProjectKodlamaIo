﻿using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            foreach (var product in productManager.getAllProducts())
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
