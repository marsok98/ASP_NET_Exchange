using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_NET_Exchange
{
    /// <summary>
    /// this class allow us to fetch and save data to this fields
    /// ten format jest znany z gory
    /// </summary>
    class ExchangeRateFromApi
    {
        public string Disclaimer { set; get; }
        public string License { set; get; }
        public int timeStamp { set; get; }

        public string Baza { set; get; }
        public  Dictionary<string,decimal> Rates { set; get; }

    }
}
