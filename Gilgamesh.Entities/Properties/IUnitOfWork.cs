using Gilgamesh.Entities.StaticData;

namespace Gilgamesh.Entities
{
    public interface IUnitOfWork
    {
        #region StaticData
        IRepository<Currency> CurrencyRepository { get;  }
        IRepository<CommonNonWorkingDay> CommonNonWorkingDayRepository { get; }

        #endregion StaticData

        int Complete();
        void Rollback();
    }
}