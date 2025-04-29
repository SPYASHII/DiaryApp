using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDatabase.Interfaces
{
    public interface ISerializationDBAccess<UType, DType>
    {
        (bool uSuc, bool dSuc) TrySave(UType user, DType diary);
        bool TrySave(DType diary);
        bool TryLoadUser(string login, out UType? user);
        bool TryLoadDiary(int id, out DType? diary);
        bool FindUser(string login);
        int GetUserIds();
        int GetDiaryIds();
    }
}
