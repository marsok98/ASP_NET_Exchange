using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using System.Net.Http;
namespace ASP_NET_Exchange
{
    public class ThreadApi
    {
        static ExchangeRateFromApi data;
        SingleCurrencyExchange singleCurrency;
        public static async void loadRate()
        {
            string call = "https://openexchangerates.org/api/latest.json?app_id=1c20a8ea81d5429cbf2fdc8fa15816a7";
            HttpClient httpClient = new HttpClient();
            string json = await httpClient.GetStringAsync(call);
            Console.WriteLine(json);
            // deserializacja
            data = JsonConvert.DeserializeObject<ExchangeRateFromApi>(json);
        }

        public void getRateByName(string nameCurrency,int amountToExchange)
        {
            decimal rate = 0;
            foreach(var x in data.Rates)
            {
                if (x.Key == nameCurrency)
                {
                    rate = x.Value;
                    singleCurrency = new SingleCurrencyExchange(data.timeStamp, nameCurrency, Decimal.ToDouble(rate), amountToExchange);
                    break;
                }
                    
            }
            
        }
    }
}
