namespace Gilgamesh.Entities
{
    public interface IUnitofWorkFactory
    {
        IUnitOfWork GetUnitOfWork();
    }
}
