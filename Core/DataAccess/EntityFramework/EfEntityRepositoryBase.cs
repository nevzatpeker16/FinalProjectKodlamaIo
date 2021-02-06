using Core.DataAcess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class, IEntity, new()
        where TContext: DbContext,new()
    {
        //Tablo tipi TEntity , TContext context tipi..
        //Entityframework kullanarak bir repository base oluşturacağız...
        //TEntity sınıf , IEntity nesnesi ve new edilebilen bir nesne olabilir,
        //TContext ise DbContext ve new edilebilen bir nesne olabilir.
        //Northwind context ten aldığımız bütün methodları direk , genel generic bir sınıf yaptık.
        public void Add(TEntity entity)
        {

            //IDisposable pattern implementation of C#
            using (TContext context = new TContext())
            {
                //Eklenecek kayıt , context product nesnesi. 
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                //Ve durumu eklenen olan oluyor.. 
                context.SaveChanges();
                //İşlemleri gerçekleştir.
            }

            //Using bittiği anda belleği garbage collector temizlesin. 
        }

        public void Delete(TEntity entity)
        {
            //IDisposable pattern implementation of C#
            using (TContext context = new TContext())
            {
                //Silinecek kayıt , context product nesnesi. 
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                //Ve durumu silinen olan oluyor.. 
                context.SaveChanges();
                //İşlemleri gerçekleştir.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                //if bloğu gibi yaptı.
                //Filtre null ise tümünü getir , değilse filtre ile yap , listeye çevir bitti.
            }

        }
        public void Update(TEntity entity)
        {
            //IDisposable pattern implementation of C#
            using (TContext context = new TContext())
            {
                //Silinecek kayıt , context product nesnesi. 
                var uptatedEntity = context.Entry(entity);
                uptatedEntity.State = EntityState.Modified;
                //Ve durumu silinen olan oluyor.. 
                context.SaveChanges();
                //İşlemleri gerçekleştir.
            }
        }
    }

}
}
