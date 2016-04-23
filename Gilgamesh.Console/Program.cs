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
using Gilgamesh.Business.Reports;
using Gilgamesh.Business.Reports.ReportOutputFormat;
using Gilgamesh.Business.Strategies;
using Gilgamesh.Entities.MarketData;
using Gilgamesh.Entities.MarketData.MarketDataRetriever;
using Gilgamesh.Entities.Portfolio;
using Gilgamesh.Entities.Portfolio.PortfolioColumns;

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
                MarketData marketData = new MarketData(unitOfWork, new MarketDataRetriever());


                var rootFolio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Find(p => p.FatherPortfolio == null).FirstOrDefault();


                var folioReport = new PortfolioReport(new List<IReportOutputFormat> {new MailReportOutputFormat()}, new List<PortfolioColumn> { new CurrencyPortfolioColumn(), new AssetValuePortfolioColumn(), new LastPortfolioColumn(), new PnlPortfolioColumn(), new LiquidCashPortfolioColumn() }, rootFolio.PortfolioId);
                folioReport.ProcessReport();

                //var instrument = unitOfWork.Instruments.Get(1);
                //var price = instrument.GetTheoreticalValue(null);

                //var share = unitOfWork.Instruments.Find(i => i.Name == "VANGUARD 500 ETF").FirstOrDefault();
                //var sharePrice = share.GetTheoreticalValue(marketData);


                //var trade = new Trade(share)
                //{
                //    Fees = 0,
                //    Quantity = 100,
                //    Price = 100,
                //    TradeDate = new DateTime(2016, 1, 4),
                //    PortfolioId = 1,
                //    Status = Status.Live
                //};
                //var perf = trade.Quantity*(trade.Instrument.GetTheoreticalValue(marketData) - trade.Price) -trade.Fees;

                //var folioRoot = unitOfWork.Portfolios.Find(p => p.FatherPortfolio == null).FirstOrDefault();
                //var saxo = folioRoot.ChildPortfolios[0].ChildPortfolios[0];
                //saxo.Load();

                //var resultValueColumn = new PnlPortfolioColumn();
                //int posCount = saxo.GetPositionsCount();
                //for (int i = 0; i < posCount; i++)
                //{
                //    var pos = saxo.GetNthPosition(i);
                //    var style = new CellStyle();
                //    var value = new CellValue();
                //    string currencySymbol = unitOfWork.CurrencyRepository.Get(pos.GetCurrencyCode()).CurrencyName;
                //    resultValueColumn.GetPositionCell(pos,style, value);
                //    System.Console.WriteLine("Position on {0} has result : {1} {2}",pos.Instrument.Name,value.DecimalValue,currencySymbol );
                //}

                //var styleFolio = new CellStyle();
                //var valueFolio = new CellValue();

                //resultValueColumn.GetPortfolioCell(saxo.PortfolioId,styleFolio, valueFolio);
                //System.Console.WriteLine("Portfolio {0} has result : {1} {2}", saxo.Name, valueFolio.DecimalValue, saxo.PortfolioCurrency.CurrencyName);


                //folioRoot.Load();

                //var liquiditiesColumn = new LiquidCashPortfolioColumn();
                //styleFolio = new CellStyle();
                //valueFolio = new CellValue();
                //liquiditiesColumn.GetPortfolioCell(folioRoot.PortfolioId, styleFolio, valueFolio);
                //System.Console.WriteLine("Portfolio {0} has liquid cash {1} {2}", folioRoot.Name,valueFolio.DecimalValue, folioRoot.PortfolioCurrency.CurrencyName);



                //var assetValueColumn = new AssetValuePortfolioColumn();
                //styleFolio = new CellStyle();
                //valueFolio = new CellValue();
                //assetValueColumn.GetPortfolioCell(folioRoot.PortfolioId,styleFolio,valueFolio);
                //System.Console.WriteLine("Portfolio {0} has Asset value : {1} {2}", folioRoot.Name, valueFolio.DecimalValue, folioRoot.PortfolioCurrency.CurrencyName);


                //var perfColumn = new PerformancePortfolioColumn();
                //saxo = folioRoot.ChildPortfolios[0].ChildPortfolios[0];

                //var positionStyle = new CellStyle();
                //var positionValue = new CellValue();
                //posCount = saxo.GetPositionsCount();
                //for (var i = 0; i < posCount; i++)
                //{
                //    var pos = saxo.GetNthPosition(i);
                //    perfColumn.GetPositionCell(pos, positionStyle, positionValue);
                //    var perfPos = positionValue.DecimalValue;
                //}

                //var forexPerfColumn = new ForexPerformancePortfolioColumn();
                //for (var i = 0; i < posCount; i++)
                //{
                //    var pos = saxo.GetNthPosition(i);
                //    forexPerfColumn.GetPositionCell(pos, positionStyle, positionValue);
                //    var perfPos = positionValue.DecimalValue;
                //}


                //styleFolio = new CellStyle();
                //valueFolio = new CellValue();

                //var cto = folioRoot.ChildPortfolios[3].ChildPortfolios[0];


                //perfColumn.GetPortfolioCell(saxo.PortfolioId, styleFolio, valueFolio);
                //var perffolio = valueFolio.DecimalValue;
                //perfColumn.GetPortfolioCell(cto.PortfolioId, styleFolio, valueFolio);
                //perffolio = valueFolio.DecimalValue;


                //posCount = cto.GetPositionsCount();
                //for (int i = 0; i < posCount; i++)
                //{
                //    var pos = cto.GetNthPosition(i);
                //    var style = new CellStyle();
                //    var value = new CellValue();
                //    string currencySymbol = unitOfWork.CurrencyRepository.Get(pos.GetCurrencyCode()).CurrencyName;
                //    var fx = MarketData.GetCurrentMarketData().GetForex(pos.GetCurrencyCode(),cto.PortfolioCurrency.Id);
                //    resultValueColumn.GetPositionCell(pos, style, value);
                //    System.Console.WriteLine("Position on {0} has result : {1} {2}", pos.Instrument.Name, value.DecimalValue*fx, currencySymbol);
                //}


                //var market = unitOfWork.Markets.Get(156);
                //var isbanKHoliday = market.IsABankHoliday(new DateTime(2016,5,16));
                //var nextWorkingDay = market.GetNextWorkingDay(new DateTime(2015, 12, 23));
            }
        }
    }
}
