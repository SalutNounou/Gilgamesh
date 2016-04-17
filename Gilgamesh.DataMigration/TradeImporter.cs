using System;
using System.Linq;
using Gilgamesh.Entities;
using Gilgamesh.Entities.Portfolio;

namespace Gilgamesh.DataMigration
{
    public class TradeImporter
    {
        public static void ImportTrades()
        {
            ImportTradesPea();
            ImportTradesCto();
            ImportTradesSaxo();
            ImportTradesBourso();
            ImportTradesBnpCheque();
            ImportTradesLivretA();
            ImportTradesCel();
            ImportTradesPel();
            ImportTradesAxa();
            ImportTradesRaiffeisen();
            ImportTradesSwissLife();
            ImportTradesLienhardt();
        }

        public static void ImportTradesPea()
        {
            var vianini = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Vianini Industria").FirstOrDefault();
            var folioPea = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Find(p => p.Name == "PEA Binck").FirstOrDefault();

            var tradeVianini = new Trade(vianini) {Fees = 0,PortfolioId =folioPea.PortfolioId,Price=1.4957m,Quantity = 670,Status = Status.Live,TradeDate = new DateTime(2014,04,14)};
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeVianini);

            var signauxGirod= UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Signaux Girod").FirstOrDefault();
            var tradeGirod = new Trade(signauxGirod) { Fees = 0, PortfolioId = folioPea.PortfolioId, Price = 19.0481m, Quantity = 52, Status = Status.Live, TradeDate = new DateTime(2015, 04, 10) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeGirod);

            var peel = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Peel Hotels PLC").FirstOrDefault();
            var tradePeel = new Trade(peel) { Fees = 0, PortfolioId = folioPea.PortfolioId, Price = 0.784m, Quantity = 1010, Status = Status.Live, TradeDate = new DateTime(2014, 05, 15) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradePeel);

            var natuzzi = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Natuzzi Spa-ADR").FirstOrDefault();
            var tradeNatuzzi = new Trade(natuzzi) { Fees = 0, PortfolioId = folioPea.PortfolioId, Price = 1.7196m, Quantity = 700, Status = Status.Live, TradeDate = new DateTime(2015, 03, 05) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeNatuzzi);

            var irce = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Irce Spa").FirstOrDefault();
            var tradeIrce = new Trade(irce) { Fees = 0, PortfolioId = folioPea.PortfolioId, Price = 2.016m, Quantity = 500, Status = Status.Live, TradeDate = new DateTime(2015, 03, 05) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeIrce);

            var gea = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "GEA SA").FirstOrDefault();
            var tradeGea = new Trade(gea) { Fees = 0, PortfolioId = folioPea.PortfolioId, Price = 77.8083m, Quantity = 12, Status = Status.Live, TradeDate = new DateTime(2015, 02, 09) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeGea);


            var exacompta = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Exacompta Clairefontaine").FirstOrDefault();
            var tradeExacompta = new Trade(exacompta) { Fees = 0, PortfolioId = folioPea.PortfolioId, Price = 56.6371m, Quantity = 17, Status = Status.Live, TradeDate = new DateTime(2015, 02, 10) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeExacompta);

            var dubuit = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Encres Dubuit").FirstOrDefault();
            var tradeDubuit = new Trade(dubuit) { Fees = 0, PortfolioId = folioPea.PortfolioId, Price = 1.9794m, Quantity = 530, Status = Status.Live, TradeDate = new DateTime(2015, 04, 14) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeDubuit);

            var adl = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "ADL Partner").FirstOrDefault();
            var tradeAdl = new Trade(adl) { Fees = 0, PortfolioId = folioPea.PortfolioId, Price = 17.6833m, Quantity = 60, Status = Status.Live, TradeDate = new DateTime(2015, 06, 09) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeAdl);

            var cash = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Cash Instrument EUR").FirstOrDefault();
            var tradeCash = new Trade(cash) { Fees = 0, PortfolioId = folioPea.PortfolioId, Price = 1, Quantity = 1291.29m, Status = Status.Live, TradeDate = new DateTime(2014, 04, 14) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeCash);

            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }


        public static void ImportTradesCto()
        {
            
            var folioCto = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Find(p => p.Name == "Compte Titres Binck").FirstOrDefault();

            var asia = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Asia Pacific Wire & Cable Ltd").FirstOrDefault();
            var tradeAsia = new Trade(asia) { Fees = 0, PortfolioId = folioCto.PortfolioId, Price = 1.7601m, Quantity = 670, Status = Status.Live, TradeDate = new DateTime(2015, 09, 02) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeAsia);

            var deswell = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Deswell Industries Inc").FirstOrDefault();
            var tradeDeswell = new Trade(deswell) { Fees = 0, PortfolioId = folioCto.PortfolioId, Price = 1.811m, Quantity = 600, Status = Status.Live, TradeDate = new DateTime(2015, 07, 06) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeDeswell);

            var dundee = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Dundee Precious Metals Inc.").FirstOrDefault();
            var tradeDundee = new Trade(dundee) { Fees = 0, PortfolioId = folioCto.PortfolioId, Price = 2.0748m, Quantity = 730, Status = Status.Live, TradeDate = new DateTime(2015, 08, 04) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeDundee);

            var emerson = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Emerson Radio Corp.").FirstOrDefault();
            var tradeEmerson = new Trade(emerson) { Fees = 0, PortfolioId = folioCto.PortfolioId, Price = 1.36m, Quantity = 807, Status = Status.Live, TradeDate = new DateTime(2015, 05, 06) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeEmerson);

            var global = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Global sources Ltd").FirstOrDefault();
            var tradeGlobal = new Trade(global) { Fees = 0, PortfolioId = folioCto.PortfolioId, Price = 5.63m, Quantity = 205, Status = Status.Live, TradeDate = new DateTime(2015, 05, 06) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeGlobal);

            var hyduke = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Hyduke Energy Services Inc").FirstOrDefault();
            var tradeHiyduke = new Trade(hyduke) { Fees = 0, PortfolioId = folioCto.PortfolioId, Price = 0.3034m, Quantity = 5013, Status = Status.Live, TradeDate = new DateTime(2015, 09, 02) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeHiyduke);


            var mbl = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "MBL Group PLC").FirstOrDefault();
            var tradeMbl = new Trade(mbl) { Fees = 0, PortfolioId = folioCto.PortfolioId, Price = 0.0749m, Quantity = 9950, Status = Status.Live, TradeDate = new DateTime(2015, 08, 03) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeMbl);

            
            var cash=  UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Cash Instrument EUR").FirstOrDefault();
            var tradeCash = new Trade(cash) { Fees = 0, PortfolioId = folioCto.PortfolioId, Price =1, Quantity = 762.63m, Status = Status.Live, TradeDate = new DateTime(2015, 05, 06) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeCash);

            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }


        public static void ImportTradesSaxo()
        {

            var folioSaxo = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Find(p => p.Name == "Compte Titres Saxobank").FirstOrDefault();

            var gld = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "SPDR Gold Shares").FirstOrDefault();
            var tradeGld = new Trade(gld) { Fees = 22.74m, PortfolioId = folioSaxo.PortfolioId, Price = 118.09m, Quantity = 43, Status = Status.Live, TradeDate = new DateTime(2016, 04, 14) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeGld);

            var rem = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "VANGUARD REIT ETF").FirstOrDefault();
            var tradeRem = new Trade(rem) { Fees = 22.73m, PortfolioId = folioSaxo.PortfolioId, Price = 83.17m, Quantity = 61, Status = Status.Live, TradeDate = new DateTime(2016, 04, 14) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeRem);

            

            var cash = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Cash Instrument CHF").FirstOrDefault();
            var tradeCash = new Trade(cash) { Fees = 0, PortfolioId = folioSaxo.PortfolioId, Price = 1, Quantity = 90.80m, Status = Status.Live, TradeDate = new DateTime(2016, 04, 14) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeCash);

            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }


        public static void ImportTradesBourso()
        {
            var folio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Find(p => p.Name == "Compte Cheque Boursorama").FirstOrDefault();

            var cash = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Cash Instrument EUR").FirstOrDefault();
            var tradeCash = new Trade(cash) { Fees = 0, PortfolioId = folio.PortfolioId, Price = 1, Quantity = 2549.61m, Status = Status.Live, TradeDate = new DateTime(2016, 04, 14) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeCash);

            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }

        public static void ImportTradesBnpCheque()
        {
            var folio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Find(p => p.Name == "Compte Cheque BNP").FirstOrDefault();

            var cash = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Cash Instrument EUR").FirstOrDefault();
            var tradeCash = new Trade(cash) { Fees = 0, PortfolioId = folio.PortfolioId, Price = 1, Quantity = 1291.75m, Status = Status.Live, TradeDate = new DateTime(2016, 04, 14) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeCash);

            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }

        public static void ImportTradesLivretA()
        {
            var folio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Find(p => p.Name == "Livret A BNP").FirstOrDefault();

            var cash = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Cash Instrument EUR").FirstOrDefault();
            var tradeCash = new Trade(cash) { Fees = 0, PortfolioId = folio.PortfolioId, Price = 1, Quantity = 4677.37m, Status = Status.Live, TradeDate = new DateTime(2016, 04, 14) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeCash);

            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }

        public static void ImportTradesPel()
        {
            var folio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Find(p => p.Name == "PEL BNP").FirstOrDefault();

            var cash = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Cash Instrument EUR").FirstOrDefault();
            var tradeCash = new Trade(cash) { Fees = 0, PortfolioId = folio.PortfolioId, Price = 1, Quantity = 3311.46m, Status = Status.Live, TradeDate = new DateTime(2016, 04, 14) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeCash);

            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }

        public static void ImportTradesCel()
        {
            var folio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Find(p => p.Name == "CEL BNP").FirstOrDefault();

            var cash = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Cash Instrument EUR").FirstOrDefault();
            var tradeCash = new Trade(cash) { Fees = 0, PortfolioId = folio.PortfolioId, Price = 1, Quantity = 462.56m, Status = Status.Live, TradeDate = new DateTime(2016, 04, 14) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeCash);

            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }

        public static void ImportTradesLienhardt()
        {
            var folio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Find(p => p.Name == "Compte Lienhardt & Partner").FirstOrDefault();

            var cash = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Cash Instrument CHF").FirstOrDefault();
            var tradeCash = new Trade(cash) { Fees = 0, PortfolioId = folio.PortfolioId, Price = 1, Quantity = 498m, Status = Status.Live, TradeDate = new DateTime(2016, 04, 14) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeCash);

            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }

        public static void ImportTradesSwissLife()
        {
            var folio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Find(p => p.Name == "Assurance Vie Swiss Life").FirstOrDefault();

            var cash = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Cash Instrument CHF").FirstOrDefault();
            var tradeCash = new Trade(cash) { Fees = 0, PortfolioId = folio.PortfolioId, Price = 1, Quantity = 564m, Status = Status.Live, TradeDate = new DateTime(2016, 04, 14) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeCash);

            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }

        public static void ImportTradesAxa()
        {
            var folio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Find(p => p.Name == "Epargne Salariale Axa").FirstOrDefault();

            var cash = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Cash Instrument EUR").FirstOrDefault();
            var tradeCash = new Trade(cash) { Fees = 0, PortfolioId = folio.PortfolioId, Price = 1, Quantity = 1323m, Status = Status.Live, TradeDate = new DateTime(2016, 04, 14) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeCash);

            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }

        public static void ImportTradesRaiffeisen()
        {
            var folio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Find(p => p.Name == "Compte Paiment Raiffeisen").FirstOrDefault();

            var cash = UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Find(i => i.Name == "Cash Instrument CHF").FirstOrDefault();
            var tradeCash = new Trade(cash) { Fees = 0, PortfolioId = folio.PortfolioId, Price = 1, Quantity = 3921m, Status = Status.Live, TradeDate = new DateTime(2016, 04, 14) };
            UnitOfWorkFactory.Instance.UnitOfWork.Trades.Add(tradeCash);

            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }



    }
}