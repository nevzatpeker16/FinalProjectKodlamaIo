using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{


    //Temel Void'ler için başlangıç .. 
   public  interface IResult
    {
         bool Success { get;}
        //Sadece okunabilir.
        string  Message { get; }
        //Sadece okunabilir.



        //Boolean olan Success mesajı bu işlemin başarılı olma durumu hakkında bilgi verecek . 
        //Message ise burada işlem ile alakalı mesaj vermemizi sağlayacak.
        //Void olan fonksiyonlar için kullanacağız. 
    }
}
