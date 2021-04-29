using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP_NET_Exchange.Data;

namespace ASP_NET_Exchange
{
    public class IndexModel : PageModel
    {
        private readonly ASP_NET_Exchange.Data.ASP_NET_ExchangeContext _context;

        public IndexModel(ASP_NET_Exchange.Data.ASP_NET_ExchangeContext context)
        {
            _context = context;
        }

        public IList<SingleCurrencyExchange> SingleCurrencyExchange { get;set; }

        public async Task OnGetAsync()
        {
            SingleCurrencyExchange = await _context.SingleCurrencyExchange.ToListAsync();
        }
    }
}
