using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //TEMEL VOIDLER İÇİN BAŞLANGIÇ
    public interface IResult
    {
        public bool Success { get; } // sadece okuma yapılacağı için set'e ihtiyaç yok.

        public string Message { get; } 
    }
}
