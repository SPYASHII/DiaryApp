using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUserInterface.Interfaces
{
    internal interface IUserInterface : IInput, IOutput
    {
        void NewPage();
        void WaitForUser();
    }
}
