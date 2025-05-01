using MainComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Interfaces.Controllers
{
    public interface IAuthDataController
    {
        bool GetCurrentUser(out User? user);
        bool UserExists(string login);
        bool LoadUser(string login);
        bool CreateUser(string login, string password);
        void ClearCurrentData();
    }
}
