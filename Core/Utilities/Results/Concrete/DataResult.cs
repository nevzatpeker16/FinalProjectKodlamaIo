using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    //Generic Tip verildi.
    {
        public DataResult(T data,bool success,string message):base(success,message)
        {
            Data = data;
        }
        public DataResult(T data,bool success):base(success)
        {
            Data = data;

        }
        //Bu şekilde Success ve Message yi gönderecek kodu yazmadık.
        //Mesaj yazmadan da direk sadece data gönderimi ve success durumu gönderildi.

        public T Data { get; }
        //T Data için getter koyuldu.

    }
}
