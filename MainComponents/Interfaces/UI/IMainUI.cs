using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainComponents.Models;

namespace MainComponents.Interfaces.UI
{
    internal interface IMainUI : IOutput
    {
        string GetTextForDate(DateTime date);
        void ShowEntries(List<Entry> entries);
        void ShowEntrySaved();
    }
}
