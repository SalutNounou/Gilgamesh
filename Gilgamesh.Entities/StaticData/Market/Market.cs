
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Gilgamesh.Entities.StaticData.Currency;

namespace Gilgamesh.Entities.StaticData.Market

{
    public class Market : Calendar, IMarket
    {
        
        public string MarketName { get; set; }
        public int MarketCurrencyId { get; set; }
        public string MarketAcronym { get; set; }
        
        public Market(): base()
        {
            
        }

        public Market(List<BankHoliday> bankHolidays) : base(bankHolidays)
        {
            
        }

        public Market(List<BankHoliday> bankholidays, List<CommonNonWorkingDay> commomnNonWorkingDays) : base(commomnNonWorkingDays, bankholidays)
        {
            
        }
    }
}