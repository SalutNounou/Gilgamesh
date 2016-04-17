using System.Collections.Generic;
using System.Linq;
using Gilgamesh.Entities.StaticData.Currency;

namespace Gilgamesh.Entities.Portfolio
{
    public class Portfolio
    {

        private readonly List<Position> _positions;

        public Portfolio()
        {
            _positions = new List<Position>();
        }


        public int PortfolioId { get; set; } 
        public virtual Currency PortfolioCurrency { get; set; }
        public bool IsStrategy { get; set; }
        public Portfolio FatherPortfolio { get; set; }
        public virtual List<Portfolio> ChildPortfolios { get; set; }
        public byte [] RowVersion { get; set; }
        public string Name { get; set; }
        public void Load()
        {
            foreach (Portfolio childPortfolio in ChildPortfolios)
            {
                childPortfolio.Load();
            }
            LoadPositionsCurrentPortfolio();
        }

        private void LoadPositionsCurrentPortfolio()
        {
            _positions.Clear();
            var instrumentsInPortfolio = UnitOfWorkFactory.Instance.UnitOfWork.Trades.GetInstrumentsInPortfolio(PortfolioId);
            var date = MarketData.MarketData.GetCurrentMarketData().GetDate();
            foreach (int instrumentId in instrumentsInPortfolio)
            {
                var trades =
                    UnitOfWorkFactory.Instance.UnitOfWork.Trades.GetLiveTradeForFolioAndInstrumentAtDate(PortfolioId,
                        instrumentId, date);

                var enumerable = trades as List<Trade> ?? trades.ToList();
                var position = new Position
                {
                    Instrument = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Get(instrumentId),
                    PortfolioId = PortfolioId,
                    SecuritiesNumber = enumerable.Sum(t => t.Quantity),
                    Trades = enumerable,
                    PositionId = 1000*PortfolioId + instrumentId
                };
                _positions.Add(position);
            }
        }

        public int GetPositionsCount()
        {
            return _positions.Count;
        }

        public Position GetNthPosition(int which)
        {
            return _positions[which];
        }

    }
}