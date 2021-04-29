using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using System.Net.Http;
using ASP_NET_Exchange.Data;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Exchange
{
    public class ThreadApi
    {
        static ExchangeRateFromApi data;
        SingleCurrencyExchange singleCurrency;
        ASP_NET_ExchangeContext dataBase = new ASP_NET_ExchangeContext(new DbContextOptionsBuilder<ASP_NET_ExchangeContext>()
.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WebApplication3Context-6c28e34d-e6cb-4189-9bb9-60ff82f2a08f;Trusted_Connection=True;MultipleActiveResultSets=true")
.Options);
        public static async void loadRate()
        {
            string call = "https://openexchangerates.org/api/latest.json?app_id=1c20a8ea81d5429cbf2fdc8fa15816a7";
            HttpClient httpClient = new HttpClient();
            string json = await httpClient.GetStringAsync(call);
            Console.WriteLine(json);
            // deserializacja
            data = JsonConvert.DeserializeObject<ExchangeRateFromApi>(json);

        }

        public void exchangeCurrency(string nameCurrency,int amountToExchange)
        {
            decimal rate = 0;
            foreach(var x in data.Rates)
            {
                if (x.Key == nameCurrency)
                {
                    rate = x.Value;
                    singleCurrency = new SingleCurrencyExchange(data.timeStamp, nameCurrency, Decimal.ToDouble(rate), amountToExchange);
                    dataBase.Add(singleCurrency);
                    dataBase.SaveChanges();
                    break;
                }      
            } 
        }


    }
}
