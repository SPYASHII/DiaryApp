using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Interfaces
{
    public interface IDataBaseBuilder
    {
        IDatabaseAccess GetDatabaseAccess();
    }
}
