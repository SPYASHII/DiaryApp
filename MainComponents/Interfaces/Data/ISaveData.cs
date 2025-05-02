using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Interfaces.Data
{
    public interface ISaveData
    {
        bool SaveUserData();
        bool SaveDiaryData();
        bool SaveData();
    }
}
