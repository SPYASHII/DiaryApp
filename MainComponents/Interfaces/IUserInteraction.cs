using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Interfaces
{
    public interface IUserInteraction
    {
        void ShowMessage(string message);
        string GetData();
        string GetData(string message);
    }
}
