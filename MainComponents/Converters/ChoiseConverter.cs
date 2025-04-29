using MainComponents.Enums;
using MainComponents.Interfaces.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Converters
{
    public class ChoiseConverter : ITextToChoisesConverter
    {
        private Dictionary<string, AuthChoises> _authChoices = new()
        {
            {"reg", AuthChoises.Registration},
            {"log", AuthChoises.Login},
        };
        private Dictionary<string, MainChoises> _mainChoices = new()
        {
            {"data", MainChoises.Data},
            {"quit", MainChoises.Quit},
        };
        AuthChoises ITextToAuthChoisesConverter.Convert(string text) =>
            _authChoices.TryGetValue(text, out AuthChoises auth) ? auth : AuthChoises.None;

        MainChoises ITextToMainChoisesConverter.Convert(string text) =>
            _mainChoices.TryGetValue(text, out MainChoises main) ? main : MainChoises.None;

    }
}
