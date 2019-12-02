using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyChanger_API.Models
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Currencies
    {

        private CurrenciesCOUNTRY[] cOUNTRYField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("COUNTRY")]
        public CurrenciesCOUNTRY[] COUNTRY
        {
            get
            {
                return this.cOUNTRYField;
            }
            set
            {
                this.cOUNTRYField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CurrenciesCOUNTRY
    {

        private string currencyField;

        private decimal rateField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal rate
        {
            get
            {
                return this.rateField;
            }
            set
            {
                this.rateField = value;
            }
        }
    }
    public class CurrencyRates
    {
        public string currencyField { get; set; }

        public decimal rateField { get; set; }

        public CurrencyRates(string name,decimal rate)
        {
            currencyField = name;
            rateField = rate;
        }

        public CurrencyRates() { }
    }

    public class RequestConvertRate
    {
        public decimal amount { get; set; }
        public string fromCurrency { get; set; }
        public string toCurrency { get; set; }
    }

}