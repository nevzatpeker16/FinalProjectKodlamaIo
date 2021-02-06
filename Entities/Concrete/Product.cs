using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        //Her taraftan erişilebilmesi için public oldu !!.
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }

        public short UnitsInStock { get; set; }
        //Short İnt!.

        public decimal UnitPrice { get; set; }


    }
}
