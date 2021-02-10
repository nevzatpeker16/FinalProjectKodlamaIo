using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true,message)
        {


        }

        public SuccessResult() : base(true)
        {

        }
    }
}
//Base yani ana sınıfa birşey gönderilecekse . :base şeklinde olur.
//Burada direk success direk true gönderir. 