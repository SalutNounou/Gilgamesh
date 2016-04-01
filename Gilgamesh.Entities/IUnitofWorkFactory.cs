using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilgamesh.Entities
{
    public interface IUnitofWorkFactory
    {
        IUnitOfWork GetUnitOfWork();
    }
}
