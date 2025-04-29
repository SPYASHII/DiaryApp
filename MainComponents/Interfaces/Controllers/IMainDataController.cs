using MainComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Interfaces.Controllers
{
    public interface IMainDataController
    {
        bool LoadDiary();
        bool GetCurrentUser(out User? user);
        bool GetCurrentDiary(out Diary? diary);
        bool SaveUserData();
        bool SaveDiaryData();
        bool SaveData();
        void ClearCurrentData();
    }
}
