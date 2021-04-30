using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP_NET_Exchange.Data;
using System.Net.Http;
using Newtonsoft.Json;

namespace ASP_NET_Exchange
{
    public class CreateModel : PageModel
    {
        
        private readonly ASP_NET_Exchange.Data.ASP_NET_ExchangeContext _context;

        public CreateModel(ASP_NET_Exchange.Data.ASP_NET_ExchangeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SingleCurrencyExchange SingleCurrencyExchange { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string call = "https://openexchangerates.org/api/latest.json?app_id=1c20a8ea81d5429cbf2fdc8fa15816a7";
            HttpClient httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(call);
            Console.WriteLine(json);
            // deserializacja
            var data = JsonConvert.DeserializeObject<ExchangeRateFromApi>(json);
            foreach (var x in data.Rates)
            {
                if (x.Key == SingleCurrencyExchange.nameOfCurrency)
                {
                    SingleCurrencyExchange.timeStamp = data.timeStamp;
                    SingleCurrencyExchange.exchangeRate = (double)x.Value;
                    SingleCurrencyExchange.resultOfCalculating = (double)(x.Value * SingleCurrencyExchange.amountToExchange);
                    break;
                }
            }
            _context.SingleCurrencyExchange.Add(SingleCurrencyExchange);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
