using MainComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Interfaces.Data
{
    public interface IGetCurrentDiary
    {
        bool GetCurrentDiary(out Diary? diary);
    }
}
