using MainComponents.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Interfaces.Converters
{
    public interface ITextToMainChoises
    {
        MainChoises Convert(string text);
    }
}
