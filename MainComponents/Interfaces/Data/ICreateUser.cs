using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Interfaces.Data
{
    public interface ICreateUser
    {
        bool CreateUser(string login, string password);
    }
}
