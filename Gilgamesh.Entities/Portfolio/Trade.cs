using System;
using Gilgamesh.Entities.Instruments;

namespace Gilgamesh.Entities.Portfolio
{
    public class Trade : ITrade
    {
        public Trade(Instrument instrument)
        {
            Instrument = instrument;
        }

        public Trade()
        {
                
        }
        public int PortfolioId { get; set; }
        public int TradeId { get; set; }
        public virtual Instrument Instrument { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Fees { get; set; }
        public DateTime TradeDate { get; set; }
        public Status Status { get; set; }
        public byte[] RowVersion { get; set; }
    }
}