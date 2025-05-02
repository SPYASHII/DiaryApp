using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUserInterface.Interfaces
{
    internal interface IOutput
    {
        void ShowData(string text);
        void ShowError(string text);
    }
}
