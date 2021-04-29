using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASP_NET_Exchange;

namespace ASP_NET_Exchange.Data
{
    public class ASP_NET_ExchangeContext : DbContext
    {
        public ASP_NET_ExchangeContext (DbContextOptions<ASP_NET_ExchangeContext> options)
            : base(options)
        {
        }

        public DbSet<ASP_NET_Exchange.SingleCurrencyExchange> SingleCurrencyExchange { get; set; }
    }
}
