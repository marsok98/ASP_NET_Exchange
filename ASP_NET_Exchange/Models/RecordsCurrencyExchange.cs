using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ASP_NET_Exchange
{
    /// <summary>
    /// klasa ktora dziedziczy bo DbContext ktory zapewnia tam cos z entity framework
    /// </summary>
    public class RecordsCurrencyExchange: DbContext
    {
        /// <summary>
        /// troche nie rozumiem dlaczego virtual
        /// 
        /// </summary>
        public virtual DbSet<SingleCurrencyExchange> SingleCurrencyExchanges { get; set; }

    }
}
