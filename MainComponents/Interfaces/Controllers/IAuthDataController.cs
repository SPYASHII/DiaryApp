using MainComponents.Interfaces.Data;
using MainComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Interfaces.Controllers
{
    public interface IAuthDataController : 
        IClearData, IGetCurrentUser,
        ILoadUser, ICreateUser,
        ICheckUser
    {
    }
}
