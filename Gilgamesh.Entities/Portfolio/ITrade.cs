using System;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
using Gilgamesh.Entities.Instruments;

namespace Gilgamesh.Entities.Portfolio
{
    public interface ITrade
    {
        int TradeId { get; set; }
        IInstrument Instrument { get;  }
        decimal Quantity { get; set; }
        decimal Price { get; set; }
        decimal Fees { get; set; }
        DateTime TradeDate { get; set; }
        Status Status { get; set; }
        int PortfolioId { get; set; }
    }
}