using System;
using Gilgamesh.Entities.Instruments;

namespace Gilgamesh.Entities.Portfolio
{
    public class Trade : ITrade
    {
        public Trade(IInstrument instrument)
        {
            Instrument = instrument;
        }
        public int PortfolioId { get; set; }
        public int TradeId { get; set; }
        public IInstrument Instrument { get; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Fees { get; set; }
        public DateTime TradeDate { get; set; }
        public Status Status { get; set; }
        public byte[] RowVersion { get; set; }
    }
}