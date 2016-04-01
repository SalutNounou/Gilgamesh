using Gilgamesh.Entities.StaticData;

namespace Gilgamesh.Entities
{
    public interface IUnitOfWork
    {
        #region StaticData
        IRepository<CurrencyEntity> CurrencyRepository { get; }
        #endregion StaticData

        

        int Complete();
        void Rollback();
    }
}