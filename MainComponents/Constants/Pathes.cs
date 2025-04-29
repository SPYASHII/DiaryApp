using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainComponents.Interfaces;
using MainComponents.Interfaces.Constants;

namespace MainComponents.Constants
{
    public class Pathes : IDatabasePath
    {
        public string DataBasePath { get; } = "storage";
    }
}
