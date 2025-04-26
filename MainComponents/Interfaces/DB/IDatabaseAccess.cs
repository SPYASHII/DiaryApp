using MainComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MainComponents.Interfaces.DB
{
    public interface IDatabaseAccess
    {
        (bool uSuc, bool dSuc) TrySave(User user, Diary diary);
        bool TrySave(Diary diary);
        bool TryLoadUser(string login, out User user);
        bool TryLoadDiary(int id, out Diary diary);
        bool FindUser(string login);
    }
}
