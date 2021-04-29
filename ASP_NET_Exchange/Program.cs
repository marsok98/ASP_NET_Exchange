using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace ASP_NET_Exchange
{
    public class Program
    {
        public async void load()
        {
            string call = "https://openexchangerates.org/api/latest.json?app_id=1c20a8ea81d5429cbf2fdc8fa15816a7";
            HttpClient httpClient = new HttpClient();
            string json = await httpClient.GetStringAsync(call);
            Console.WriteLine(json);
            // deserializacja
            var data = JsonConvert.DeserializeObject<ExchangeRateFromApi>(json);
            //wypelnianie list view
            foreach (var x in data.Rates)
            {
                //ListViewItem a = new ListViewItem(x.Key);
                //a.SubItems.Add(x.Value.ToString());
                //listView1.Items.Add(a);
            }
            //wypelnianie
            foreach (var item in data.Rates.Keys)
            {
                //comboBoxChooseCurrency.Items.Add(item);
                //comboBoxToFindCurrency.Items.Add(item);
            }
            //timeStamp = data.timeStamp;
            //textBoxtimeStamp.Text = UnixTimeToDateTime(data.timeStamp).ToString();
        }



        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
