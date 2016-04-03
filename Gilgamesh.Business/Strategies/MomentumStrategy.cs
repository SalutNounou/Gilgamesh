using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gilgamesh.Entities.MarketData;
using Gilgamesh.Entities.MarketData.MarketDataRetriever;

namespace Gilgamesh.Business.Strategies
{
    public class MomentumStratgy : IStrategy
    {
        private const string SAndP500Ticker = @"^GSPC";
        private const string MsciWorldMinusUsTicker = "VEU";
        private const string BillsTicker = @"^IRX";


        private static readonly  Dictionary<ActionsMomentumStrategy, string> Actions = new Dictionary<ActionsMomentumStrategy, string>
        {
            {ActionsMomentumStrategy.BuySandP500, "Buy S&P500." },
            {ActionsMomentumStrategy.BuyMsciWorlMinusUs, "Buy MSCI World Minus US." },
            {ActionsMomentumStrategy.BuyTreasuryBonds, "Buy T Bills." },
            {ActionsMomentumStrategy.StayLiquid, "Stay Liquid." }
        };

        private readonly IMarketDataRetriever _marketDataRetriever;

        public MomentumStratgy(IMarketDataRetriever marketDataRetriever)
        {
            _marketDataRetriever = marketDataRetriever;
        }

        public void RunStrategy()
        {
            DateTime today = DateTime.Now;
            var actionToday = GetInvestmentAction(today);
            var actionMonthMinusOne = GetInvestmentAction(today.AddMonths(-1));
            var tendencyChange = actionToday != actionMonthMinusOne;
            StringBuilder actionText = new StringBuilder().Append(tendencyChange?"!!!Momentum change!!!  : ":"Momentum goes ahead  :  ").Append(Actions[actionToday]);
            Utils.Mail.MailUtil.SendMail("thisisjulienh@gmail.com","Momentum Strategy : Action of the month", actionText.ToString());

        }

        private ActionsMomentumStrategy GetInvestmentAction(DateTime date)
        {
            var fixingsSAndP500 = _marketDataRetriever.GetHistoricalFixings(SAndP500Ticker, date.AddYears(-1), date);
            var fixingsWorldMinusUs = _marketDataRetriever.GetHistoricalFixings(MsciWorldMinusUsTicker,
                date.AddYears(-1), date);
            var fixingsTBills = _marketDataRetriever.GetHistoricalFixings(BillsTicker, date.AddYears(-1), date);

            var perfSAndP = CalculatePerformance(fixingsSAndP500);
            var perfWorld = CalculatePerformance(fixingsWorldMinusUs);
            var perfBills = CalculatePerformance(fixingsTBills);

            ActionsMomentumStrategy action = DecideWhatToBuy(perfSAndP, perfWorld, perfBills);
            return action;
        }


        private ActionsMomentumStrategy DecideWhatToBuy(decimal perfSAndP, decimal perfWorld, decimal perfBills)
        {
            ActionsMomentumStrategy result;
            if (perfSAndP >= perfWorld)
            {
                if(perfSAndP>=perfBills)
                    result= ActionsMomentumStrategy.BuySandP500;
                else
                {
                    result = ActionsMomentumStrategy.BuyTreasuryBonds;
                }
            }
            else
            {
                if (perfWorld >= perfBills)
                {
                    result= ActionsMomentumStrategy.BuyMsciWorlMinusUs;
                }
                else
                {
                    result= ActionsMomentumStrategy.BuyTreasuryBonds;
                }
            }
            if(Math.Max(perfBills, Math.Max(perfSAndP, perfWorld)) <= 0)
                result=ActionsMomentumStrategy.StayLiquid;
            return result;
        }

        private  decimal CalculatePerformance(List<Fixings> fixings)
        {
            decimal perf = 0;
            var fixingLastYear = fixings.LastOrDefault();
            var fixingToday = fixings.FirstOrDefault();
            if (fixingToday != null && fixingLastYear != null)
                perf = (fixingToday.Last / fixingLastYear.Last) - 1;
            return perf;
        }
    }
}