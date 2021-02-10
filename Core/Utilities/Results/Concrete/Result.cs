using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{

    //Result çıplak kalmaması için IResult implementasyonu yaptık..
    public class Result : IResult
    {
        public Result(bool success, string message):this(success)
        {
            Message = message;
            //Constructor vasıtası ile Success ve Message set edildi.
            //Read only sadece okuma modunda olan alanlar bile constructor ile set edilebilir
            //Mesaj göndermek istersen , 2 parametre gönderdiğinde 18. satır da çalışacak . 
            //Eğer sadece success gönderirsen sadece success olan constructor çalışır.
        }
        public Result(bool succes)
        {
            Success = succes;
        }
        //Constructor overload edildi.

        public bool Success { get; }

        public string Message { get; }

    }
}
