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
    public class DetailsModel : PageModel
    {
        private readonly ASP_NET_Exchange.Data.ASP_NET_ExchangeContext _context;

        public DetailsModel(ASP_NET_Exchange.Data.ASP_NET_ExchangeContext context)
        {
            _context = context;
        }

        public SingleCurrencyExchange SingleCurrencyExchange { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SingleCurrencyExchange = await _context.SingleCurrencyExchange.FirstOrDefaultAsync(m => m.ID == id);

            if (SingleCurrencyExchange == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
