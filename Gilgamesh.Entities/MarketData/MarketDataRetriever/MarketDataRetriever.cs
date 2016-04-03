using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using Gilgamesh.Entities.StaticData.Currency;
// ReSharper disable InconsistentNaming

namespace Gilgamesh.Entities.MarketData.MarketDataRetriever
{
    public class MarketDataRetriever : IMarketDataRetriever
    {
        
        public decimal GetLast(string ticker)
        {
            var result = GetLast(new List<string> { ticker });
            return result.Count > 0 ? result[0].Last : 0;
        }

        public List<Fixings> GetLast(List<string> ticker)
        {
            try
            {
                string csvData;
                using (WebClient web = new WebClient())
                {
                    csvData =
                        web.DownloadString(String.Format("http://finance.yahoo.com/d/quotes.csv?s={0}&f=sl1",
                            String.Join("+", ticker.ToArray())));
                }
                var result = new List<Fixings>();
                var lines = csvData.Split('\n');
                foreach (string line in lines.Where(c => c != string.Empty))
                {
                    var fixings = new Fixings();
                    var columns = line.Split(',');
                    fixings.Reference = columns[0];
                    fixings.Last = Convert.ToDecimal(columns[1], CultureInfo.InvariantCulture.NumberFormat);
                    fixings.Fixingdate = DateTime.Now;
                    result.Add(fixings);
                }
                return result;
            }
            catch (Exception e)
            {
                throw new MarketDataRetrieverException(e);
            }
        }

        public List<Fixings> GetHistoricalFixings(string ticker, DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                string csvData;
                using (WebClient client = new WebClient())
                {
                    var query =
                        String.Format(
                            "http://ichart.finance.yahoo.com/table.csv?s={0}&d={1}&e={2}&f={3}&g=d&a={4}&b={5}&c={6}&ignore=.csv",
                            ticker, dateTo.Month - 1, dateTo.Day, dateTo.Year, dateFrom.Month - 1, dateFrom.Day,
                            dateFrom.Year);
                    csvData = client.DownloadString(query);
                }
                var lines = csvData.Split('\n').ToList();
                if (lines.Count > 0) lines.RemoveAt(0);
                var result = new List<Fixings>();
                foreach (string line in lines.Where(c => c != string.Empty))
                {
                    var columns = line.Split(',');
                    const string format = "yyyy-MM-dd";
                    var fixings = new Fixings
                    {
                        Reference = ticker,
                        Fixingdate = DateTime.ParseExact(columns[0], format, CultureInfo.InvariantCulture),
                        Open = Convert.ToDecimal(columns[1], CultureInfo.InvariantCulture),
                        High = Convert.ToDecimal(columns[2], CultureInfo.InvariantCulture),
                        Low = Convert.ToDecimal(columns[3], CultureInfo.InvariantCulture),
                        Close = Convert.ToDecimal(columns[4], CultureInfo.InvariantCulture),
                        Volume = Convert.ToDecimal(columns[5], CultureInfo.InvariantCulture),
                        AdjustedClose = Convert.ToDecimal(columns[6], CultureInfo.InvariantCulture),
                        Last = Convert.ToDecimal(columns[4], CultureInfo.InvariantCulture)
                    };

                    result.Add(fixings);
                }
                return result;
            }
            catch (Exception e)
            {
                throw new MarketDataRetrieverException(e);
            }
        }

        public decimal GetForexLast(string currencyFrom, string currencyTo)
        {
            try
            {
                string csvData;
                using (WebClient web = new WebClient())
                {
                    string query =String.Format( "http://finance.yahoo.com/d/quotes.csv?e=.csv&f=sl1d1t1&s={0}{1}=X",currencyFrom,currencyTo);
                    csvData = web.DownloadString(query);
                }
                //"USDGBP=X",0.7028,"4/2/2016","12:53pm"
                var lines = csvData.Split('\n');
                return lines.Where(c => c != string.Empty).Select(line => line.Split(',')).Select(columns => Convert.ToDecimal(columns[1], CultureInfo.InvariantCulture.NumberFormat)).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new MarketDataRetrieverException(e);
            }
        }

        public List<Fixings> GetForexHistoricalFixings(Currency currencyFrom, Currency currencyTo, DateTime dateFrom,
            DateTime dateTo)
        {
            var fixings = new List<Fixings>();
           
            if (currencyTo == null || currencyFrom == null) return fixings;
            var currentDate = dateFrom;
            
            while (currentDate <= dateTo)
            {
                if (!currencyTo.IsABankHoliday(currentDate) && !currencyFrom.IsABankHoliday(currentDate))
                {
                    fixings.Add(GetForexAtDate(currencyFrom.CurrencyName,currencyTo.CurrencyName,currentDate));
                }
                currentDate=currentDate.AddDays(1);
            }
            return fixings;
        }

        public Fixings GetForexAtDate(string currencyFrom, string currencyTo, DateTime date)
        {
            try
            {
                string jSonData;
                const string format = "yyyy-MM-dd";
                using (WebClient web = new WebClient())
                {
                    jSonData =
                        web.DownloadString(String.Format("http://api.fixer.io/{0}?symbols={1}&base={2}", date.ToString(format, CultureInfo.InvariantCulture), currencyFrom,currencyTo));
                    jSonData=jSonData.Replace("base", "baseCurrency");
                }
                var result = new Fixings();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                JsonCurrencyFixing jsonCurrencyFixing = ser.Deserialize<JsonCurrencyFixing>(jSonData);
                if (jsonCurrencyFixing == null ||jsonCurrencyFixing.rates==null) return null;
                result.Reference = String.Format("{0}/{1}",currencyFrom,currencyTo);
                result.Fixingdate =DateTime.ParseExact( jsonCurrencyFixing.date, format, CultureInfo.InvariantCulture);
                result.Last = Convert.ToDecimal(JSonRateOuput[currencyFrom](jsonCurrencyFixing.rates),CultureInfo.InvariantCulture);
                return result;
            }
            catch (Exception e)
            {
                throw new MarketDataRetrieverException(e);
            }
        }
        private readonly static Dictionary<string, Func<JSonRate,string>> JSonRateOuput = new Dictionary<string, Func<JSonRate, string>>
        {
            {"USD", (r=>r.USD) },
            {"GBP", (r=>r.USD) },
            {"CHF", (r=>r.USD) },
            {"EUR", (r=>r.USD) },
            {"CAD", (r=>r.USD) },
            {"SGD", (r=>r.USD) },
            {"JPY", (r=>r.USD) },
            {"CNY", (r=>r.USD) },
            {"AUD", (r=>r.USD) },
            {"ARS", (r=>r.USD) },
            {"BRL", (r=>r.USD) },
            {"CLP", (r=>r.USD) },
            {"DKK", (r=>r.USD) },
            {"HKD", (r=>r.USD) },
            {"INR", (r=>r.USD) },
            {"IDR", (r=>r.USD) },
            {"ILS", (r=>r.USD) },
            {"NOK", (r=>r.USD) },
            {"MXN", (r=>r.USD) },
            {"SEK", (r=>r.USD) },
            {"TWD", (r=>r.USD) },
            {"KRW", (r=>r.USD) }
        };
    }
    
}

public class JsonCurrencyFixing
{
    public string baseCurrency { get;set;}
    public string date { get; set; }
    public JSonRate rates { get; set; }
}

public class JSonRate
{
    public string USD { get; set; }
    public string GBP{ get; set; }
    public string CHF { get; set; }
    public string EUR { get; set; }
    public string CAD { get; set; }
    public string SGD { get; set; }
    public string JPY { get; set; }
    public string CNY { get; set; }
    public string AUD { get; set; }
    public string ARS { get; set; }
    public string BRL{ get; set; }
    public string CLP { get; set; }
    public string DKK { get; set; }
    public string HKD { get; set; }
    public string INR { get; set; }
    public string IDR { get; set; }
    public string NOK { get; set; }
    public string MXN { get; set; }
    public string KRW { get; set; }
    public string SEK { get; set; }
    public string TWD { get; set; }
    public string ILS { get; set; }
}