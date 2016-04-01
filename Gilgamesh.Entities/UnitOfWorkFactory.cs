namespace Gilgamesh.Entities
{
    public class UnitOfWorkFactory : IUnitofWorkFactory
    {

        public IUnitOfWork UnitOfWork { get;set;}

        private static UnitOfWorkFactory _instance;

        private  UnitOfWorkFactory()
        {
           
        }

        private static  readonly object _instancelock = new object();

        public static UnitOfWorkFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instancelock)
                    {
                        _instance = new UnitOfWorkFactory();
                    }
                }
                return _instance;
            }
        }


        public IUnitOfWork GetUnitOfWork()
        {
            return UnitOfWork;
        }
    }
}