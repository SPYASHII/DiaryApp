using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainComponents.Enums;
using MainComponents.Models;

namespace MainComponents.Interfaces.UI
{
    public interface IMainUI : IOutput
    {
        string GetTextForDateOrChoise(DateTime date, out MainChoises choise);
        void ShowEntries(List<Entry> entries);
        void ShowResultOfEntrySaving(bool saved);
    }
}
