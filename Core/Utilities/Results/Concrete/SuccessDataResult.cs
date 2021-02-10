using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data,true,message)
        {

        }
        public SuccessDataResult(T data):base(data,true)
        {
            //Hiç mesaj vermedi direk true
        }
        public SuccessDataResult(string message):base(default,true,message)
        {
            //Default sadece message veriyor

        }
        public SuccessDataResult() : base(default,true)
        {

        }                
        
    }
}
