using System;
using System.Collections.Generic;
using System.Linq;
using Gilgamesh.Entities.Instruments;
using Gilgamesh.Entities.MarketData.MarketDataRetriever;

namespace Gilgamesh.Entities.MarketData
{
    public class MarketData : IMarketData
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMarketDataRetriever _marketDataRetriever;

        private static MarketData _currenMarketData;

        private static readonly object MarketDataLock = new object();

        public static MarketData GetCurrentMarketData()
        {
            if (_currenMarketData == null)
            {
                lock (MarketDataLock)
                {
                    _currenMarketData = new MarketData(UnitOfWorkFactory.Instance.UnitOfWork,
                        new MarketDataRetriever.MarketDataRetriever())
                    {
                        _date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                    }; //TODO : TinyIOC for marketDataRetriever and UnitOfWork
                }
            }
            return _currenMarketData;
        }

        private DateTime _date;

        public MarketData(IUnitOfWork unitOfWork, IMarketDataRetriever marketDataRetriever)
        {
            _unitOfWork = unitOfWork;
            _marketDataRetriever = marketDataRetriever;
            var today = DateTime.Now;
            _date = new DateTime(today.Year, today.Month, today.Day);
        }
        public DateTime GetDate()
        {
            return _date;
        }

        public decimal GetSpot(int instrumentId)
        {
            var instrument = _unitOfWork.Instruments.Get(instrumentId);
            if (instrument == null) return 0;
            if (instrument.GetInstrumentType() == 'C') return 1;
            var fixing = FindOrUpdateFixingForSpot(instrument);
            return fixing?.Last ?? 0;
        }

        public decimal GetForex(int currencyFrom, int currencyTo)
        {
            if (currencyFrom == currencyTo) return 1;
            var currency1 = _unitOfWork.CurrencyRepository.Get(currencyFrom);
            var currency2 = _unitOfWork.CurrencyRepository.Get(currencyTo);
            return _marketDataRetriever.GetForexAtDate(currency1.CurrencyName, currency2.CurrencyName, _date).Last;
        }

        public decimal GetForexAtDate(int currencyFrom, int currencyTo, DateTime date)
        {
            if (currencyFrom == currencyTo) return 1;
            var currency1 = _unitOfWork.CurrencyRepository.Get(currencyFrom);
            var currency2 = _unitOfWork.CurrencyRepository.Get(currencyTo);
            return _marketDataRetriever.GetForexAtDate(currency1.CurrencyName, currency2.CurrencyName, date).Last;
        }


        private Fixings FindOrUpdateFixingForSpot(Instrument instrument)
        {
            var fixing = _unitOfWork.Fixings.Find(f => f.InstrumentId == instrument.InstrumentId && f.Last != 0).FirstOrDefault();
            if (fixing == null || fixing.Last == 0)
            {
                var newFixing = _marketDataRetriever.GetLast(new List<IInstrument>{ instrument}/*new List<string> { instrument.Reference.Name }*/).FirstOrDefault();
                if (newFixing == null) return null;
                if (fixing == null)
                {
                    newFixing.InstrumentId = instrument.InstrumentId;
                    _unitOfWork.Fixings.Add(newFixing);
                    fixing = newFixing;
                }
                else if (fixing.Last == 0)
                {
                    fixing.Last = newFixing.Last;
                }
                _unitOfWork.Complete();
            }
            return fixing;
        }

    }
}