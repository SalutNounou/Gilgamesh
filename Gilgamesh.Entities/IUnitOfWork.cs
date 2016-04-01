using Gilgamesh.Entities.StaticData;

namespace Gilgamesh.Entities
{
    public interface IUnitOfWork
    {
        #region StaticData
        IRepository<CurrencyEntity> CurrencyRepository { get; set; }
        #endregion StaticData

        IUnitOfWork GetInstance();

        int Complete();
        void Rollback();
    }
}