using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_NET_Exchange
{
    public class SingleCurrencyExchange
    {
        // dlaczego dodajac w ten sposob ID, to wszystko dziala?
        //dlaczego nie musimy dodac [id] czy cos takiego
        //zapewnia to entity framework
        public int ID { set; get; }
        /// <summary>
        /// tutaj niestety do bazy danych zapisujemy time stamp w formie inta a nie dateTime
        /// Chcialem w formie dateTime ale powodowalo to ze musialbym migrowac baze danych 
        /// a tego w chwili pisania programu nie ogarnialem
        /// </summary>
        public int timeStamp { set; get; }
        /// <summary>
        /// nazwa waluty do wymiany
        /// </summary>
        public string nameOfCurrency { set; get; }
        /// <summary>
        /// kurs waluty
        /// </summary>
        public double exchangeRate { set; get; }

        /// <summary>
        /// ilosc waluty do wymiany
        /// </summary>
        public int amountToExchange { set; get; }
        /// <summary>
        /// wynik tych obliczen
        /// </summary>
        public double resultOfCalculating { set; get; }
        /// <summary>
        /// konstruktor do utworzenia tego calego obiektu
        /// </summary>
        /// <param name="time"></param>
        /// <param name="name"></param>
        /// <param name="exchangeRate"></param>
        /// <param name="amount"></param>
        /// <param name="result"></param>
        public SingleCurrencyExchange(int time, string name, double exchangeRate, int amount, double result)
        {
            this.timeStamp = time;
            this.nameOfCurrency = name;
            this.exchangeRate = exchangeRate;
            this.amountToExchange = amount;
            this.resultOfCalculating = result;
        }
        public SingleCurrencyExchange()
        {

        }
    }
}
