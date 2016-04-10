using Gilgamesh.Entities.MarketData;
using Gilgamesh.Entities.StaticData.Reference;
using Gilgamesh.Entities.StaticData.Currency;
using Gilgamesh.Entities.StaticData.Market;
using Gilgamesh.Entities.Instruments;
using Gilgamesh.Entities.Portfolio;

namespace Gilgamesh.Entities
{
    public interface IUnitOfWork
    {
        #region StaticData
        IRepository<Currency> CurrencyRepository { get; }
        IRepository<CommonNonWorkingDay> CommonNonWorkingDayRepository { get; }
        IRepository<Reference> References { get; }
        IRepository<ReferenceType> ReferenceTypes { get; }
        IRepository<Market> Markets { get; }
        IRepository<Instrument> Instruments { get; }
        ITradeRepository Trades { get; }
        IRepository<Portfolio.Portfolio> Portfolios { get; }

            #endregion StaticData

        #region MarketData
        IRepository<Fixings> Fixings { get; }
        #endregion MarketData

        int Complete();
        void Rollback();
    }
}