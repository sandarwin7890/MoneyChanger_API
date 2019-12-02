using MoneyChanger_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MoneyChanger_API.Helper
{
    public static class DAL
    {
        public static async Task<List<CurrencyRates>> getAllCurrency()
        {
            List<CurrencyRates> currencyList = await getCurrencyList();
            return currencyList;
        }

        public static async Task<List<CurrencyRates>> getCurrencyList()
        {
            Currencies result = new Models.Currencies();
            List<CurrencyRates> curList = new List<CurrencyRates>();
            CurrencyRates curRate = null;
            try
            {
                XmlSerializer seralizer = new XmlSerializer(typeof(Currencies));
                string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Currency.XML");
                if (File.Exists(filepath))
                {
                    using (FileStream fileStream = new FileStream(filepath, FileMode.Open))
                    {
                        result = (Currencies)seralizer.Deserialize(fileStream);
                    }

                    foreach (var item in result.COUNTRY)
                    {
                        curRate = new CurrencyRates();
                        curRate.currencyField = item.currency;
                        curRate.rateField = item.rate;
                        curList.Add(curRate);
                    }
                }
                else
                {
                    Console.WriteLine("No file to load data!");
                }
            }            
            catch (Exception ex)
            {
                throw (ex);
                Console.WriteLine(ex);
            }
            return await Task.FromResult(curList.ToList());
        }

        public async static Task<decimal> getRateByCurrency(string currency)
        {
            List<CurrencyRates> list = await getCurrencyList();
            decimal rate = 0;
            try
            {               
                if (list.Count > 0)
                {
                    rate = list.Where(m => m.currencyField == currency).Select(x => x.rateField).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw (ex);
                Console.WriteLine(ex);
            }
            return rate;
        }

        public async static Task<decimal> getConvertedRate(RequestConvertRate req)
        {
            decimal _amt = req.amount;
            decimal _frRate = await getRateByCurrency(req.fromCurrency);
            decimal _toRate = await getRateByCurrency(req.toCurrency);
            decimal _result = _amt / _frRate * _toRate;
            return Math.Round(_result,2);
        }
    }
}