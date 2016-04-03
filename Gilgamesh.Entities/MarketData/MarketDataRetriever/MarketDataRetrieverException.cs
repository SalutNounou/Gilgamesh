using System;

namespace Gilgamesh.Entities.MarketData.MarketDataRetriever
{
    public class MarketDataRetrieverException : System.Exception
    {
        public MarketDataRetrieverException(Exception e) : base(e.Message)
        {
            
        }

        public override string Message => string.Format("MarketDataRetrieverException : {0}", base.Message);
    }
}