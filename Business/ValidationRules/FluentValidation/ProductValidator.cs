using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class ProductValidator : AbstractValidator<Product>
    {

        //AbstractValidator kim için doğrulama yapıyor , product!
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            //Boş olamaz
            RuleFor(p => p.ProductName).MinimumLength(2);
            //En az iki karakter productname için.
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryID == 1);
            //Kategori ıd 1 olan malzemelerin fiyatları 10 dan büyük olmalı veya eşit olmalı.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi le başlamalı");


            
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
        //A ile başlamıyorsa false döner ve bu kural patlar.

    }
}
