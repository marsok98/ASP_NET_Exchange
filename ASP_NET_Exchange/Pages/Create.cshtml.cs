using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP_NET_Exchange.Data;

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

            _context.SingleCurrencyExchange.Add(SingleCurrencyExchange);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
