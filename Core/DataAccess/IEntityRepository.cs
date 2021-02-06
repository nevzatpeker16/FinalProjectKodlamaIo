using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAcess
{
    //Generic Constraint+
    //class : referans tip ve Ientity üzerinden implemente olmuş bir sınıf olabilir...
    //Tek başına IEntitiy bir nesne değil tek başına işe yaramaz , new() yazarak bir standartı oluşturduk 
    public interface IEntityRepository<T> where T:class,IEntity,new()
        //T SADECE REFERANS TİP olabilir
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        //Expression ile böylece direk  id şuna eşit buna eşit diyebiliriz.
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        // T get ile yazdığımız kodlar ile getby category ye gerek kalmıyor.
        //List<T> GetByCategory();
    }
}
