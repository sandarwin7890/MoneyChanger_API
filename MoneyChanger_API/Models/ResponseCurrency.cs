using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyChanger_API.Models
{
    public class ResponseCurrency
    {
        public string currencyName { get; set; }
        public decimal amount { get; set; }
    }
}