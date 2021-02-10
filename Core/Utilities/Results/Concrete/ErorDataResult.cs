using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{

        public class ErorDataResult<T> : DataResult<T>
        {
            public ErorDataResult(T data, string message) : base(data, false, message)
            {

            }
            public ErorDataResult(T data) : base(data, false)
            {
                //Hiç mesaj  vermedi direk false + data
            }
            public ErorDataResult(string message) : base(default, false, message)
            {
                //Default sadece message veriyor

            }
            public ErorDataResult() : base(default, false)
            {

            }

        }
    }

