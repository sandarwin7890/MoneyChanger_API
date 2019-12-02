using MoneyChanger_API.Helper;
using MoneyChanger_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MoneyChanger_API.Controllers
{
    public class ExchangeController : ApiController
    {
        [HttpGet]
        public async Task<List<CurrencyRates>> GetCurrencyList()
        {
            List<CurrencyRates> currList = await DAL.getAllCurrency();
            return currList.ToList();
        }

        [HttpPost]
        public async Task<decimal> GetConvertedCurrencyRate(RequestConvertRate request)
        {
            decimal result= await DAL.getConvertedRate(request);
            return result;
        }      
    }
}