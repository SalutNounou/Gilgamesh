using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Gilgamesh.DataAccess;
using Gilgamesh.Entities;
using Gilgamesh.Entities.StaticData;
using System.Data.Entity;
using System.Runtime.InteropServices;
using Gilgamesh.Business.Strategies;
using Gilgamesh.Entities.MarketData;
using Gilgamesh.Entities.MarketData.MarketDataRetriever;
using Gilgamesh.Entities.Portfolio;

namespace Gilgamesh.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
            {
                //IMarketDataRetriever marketDataRetriever = new MarketDataRetriever();
                ////var last = marketDataRetriever.GetForexAtDate("USD", "CHF",new DateTime(2016,3,22));
                //var momentumStrategy = new MomentumStratgy(marketDataRetriever);
                //momentumStrategy.RunStrategy();

                UnitOfWorkFactory.Instance.UnitOfWork = unitOfWork;
                MarketData marketData= new MarketData(unitOfWork, new MarketDataRetriever());

                var instrument = unitOfWork.Instruments.Get(1);
                var price = instrument.GetTheoreticalValue(null);

                var share = unitOfWork.Instruments.Find(i => i.Name == "VANGUARD 500 ETF").FirstOrDefault();
                var sharePrice = share.GetTheoreticalValue(marketData);


                var trade = new Trade(share)
                {
                    Fees = 0,
                    Quantity = 100,
                    Price = 100,
                    TradeDate = new DateTime(2016, 1, 4),
                    PortfolioId = 1,
                    Status = Status.Live
                };
                var perf = trade.Quantity*(trade.Instrument.GetTheoreticalValue(marketData) - trade.Price) -trade.Fees;

                var folioRoot = unitOfWork.Portfolios.Find(p => p.FatherPortfolio == null).FirstOrDefault();

                var market = unitOfWork.Markets.Get(156);
                var isbanKHoliday = market.IsABankHoliday(new DateTime(2016,5,16));
                var nextWorkingDay = market.GetNextWorkingDay(new DateTime(2015, 12, 23));
            }
        }
    }
}
