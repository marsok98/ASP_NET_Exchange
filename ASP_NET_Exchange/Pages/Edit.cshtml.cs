using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_NET_Exchange.Data;

namespace ASP_NET_Exchange
{
    public class EditModel : PageModel
    {
        private readonly ASP_NET_Exchange.Data.ASP_NET_ExchangeContext _context;

        public EditModel(ASP_NET_Exchange.Data.ASP_NET_ExchangeContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SingleCurrencyExchange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SingleCurrencyExchangeExists(SingleCurrencyExchange.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SingleCurrencyExchangeExists(int id)
        {
            return _context.SingleCurrencyExchange.Any(e => e.ID == id);
        }
    }
}
