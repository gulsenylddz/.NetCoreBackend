
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer : IEntity // veritabanında bulunan nesneler IEntityden inherit alır.
    {

        public string CustomerId { get; set; } // Northwind'de customerid string olarsk tutulduğu için string yaptık.
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
    }
}
