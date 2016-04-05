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

        private DateTime _date;

        public MarketData(IUnitOfWork unitOfWork, IMarketDataRetriever marketDataRetriever)
        {
            _unitOfWork = unitOfWork;
            _marketDataRetriever = marketDataRetriever;
            var today = DateTime.Now;
            _date= new DateTime(today.Year, today.Month,today.Day);
        }
        public DateTime GetDate()
        {
            return _date;
        }

        public decimal GetSpot(int instrumentId)
        {
            var instrument = _unitOfWork.Instruments.Get(instrumentId);
            if (instrument == null) return 0;
            if (instrument.GetInstrumentType()=='C')return 1;
            var fixing = FindOrUpdateFixingForSpot(instrument);
            return fixing?.Last ?? 0;
        }

        public decimal GetForex(int currencyFrom, int currencyTo)
        {
            return 0;
        }


        private Fixings FindOrUpdateFixingForSpot(Instrument instrument)
        {
            var fixing = _unitOfWork.Fixings.Find(f => f.InstrumentId == instrument.InstrumentId && f.Last != 0).FirstOrDefault();
            if (fixing == null || fixing.Last == 0)
            {
                var newFixing = _marketDataRetriever.GetLast(new List<string> { instrument.Reference.Name }).FirstOrDefault();
                if (newFixing == null) return null;
                if (fixing == null)
                {
                    newFixing.InstrumentId = instrument.InstrumentId;
                    _unitOfWork.Fixings.Add(newFixing);
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