using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Business
{
    public class BusinessRules // iş kuralların yazıldığı kısım
    {
        public static IResult Run(params IResult[] logics) //params ile istediğimiz kadar
        {                                                  //ıresult parametresi verebiliriz.
            foreach (var logic in logics) //logic-->kural
            {
                if (!logic.Success) {
                    return logic;
                }
            }
            return null;
        }                                                   
    }
}
