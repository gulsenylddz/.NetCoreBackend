using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult //generic ile döndüreceğimiz şeyin tipini belli ettik <T>
    {
        T Data { get; }
    }
}
