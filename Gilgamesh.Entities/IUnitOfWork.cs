using Gilgamesh.Entities.StaticData.Reference;
using Gilgamesh.Entities.StaticData.Currency;
using Gilgamesh.Entities.StaticData.Market;

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
        #endregion StaticData

        int Complete();
        void Rollback();
    }
}