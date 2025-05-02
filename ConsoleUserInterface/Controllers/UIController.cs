using MainComponents.Enums;
using MainComponents.Interfaces.Controllers;
using MainComponents.Interfaces.Converters;
using MainComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUserInterface.Interfaces;

namespace ConsoleUserInterface.Controllers
{
    internal class UIController : IUserInterfaceController
    {
        private ITextToAuthChoisesConverter _authConverter;
        private ITextToMainChoisesConverter _mainConverter;

        private IUserInterface _userInterface;
        public UIController(IUserInterface userInterface, ITextToChoisesConverter choiseConverter)
        {
            _authConverter = choiseConverter;
            _mainConverter = choiseConverter;

            _userInterface = userInterface;
        }
        public AuthChoises GetAuthChoise()
        {
            _userInterface.NewPage();

            _userInterface.ShowData("log to Login\n\nreg to Registration");
            string data = _userInterface.GetData();

            return _authConverter.Convert(data);
        }

        public string GetLoginFromUser()
        {
            _userInterface.NewPage();

            _userInterface.ShowData("Enter login:\n");
            string data = _userInterface.GetData();

            return data;
        }

        public string GetPasswordFromUser()
        {
            _userInterface.NewPage();

            _userInterface.ShowData("Enter password:\n");
            string data = _userInterface.GetData();

            return data;
        }

        public string GetTextForDateOrChoise(DateTime date, out MainChoises choise)
        {
            _userInterface.NewPage();

            _userInterface.ShowData(date.ToShortDateString() + "\n");
            _userInterface.ShowData("Enter a text for current date or enter data/quit");

            string data = _userInterface.GetData();

            choise = _mainConverter.Convert(data);

            return data;
        }

        public void ShowData(string text)
        {
            _userInterface.ShowData(text);
        }

        public void ShowEntries(List<Entry> entries)
        {
            _userInterface.NewPage();

            foreach (Entry entry in entries)
            {
                _userInterface.ShowData(entry.ToString());
            }

            _userInterface.WaitForUser();
        }

        public void ShowResultOfEntrySaving(bool saved)
        {
            _userInterface.NewPage();

            var resultMessage = new StringBuilder("Entry saving ");

            if (saved)
                resultMessage.Append("successfully!");
            else
                resultMessage.Append("failed!");

            _userInterface.ShowData(resultMessage.ToString());

            _userInterface.WaitForUser();
        }

        public void ShowError(string text)
        {
            _userInterface.ShowError(text);
        }

        public void ShowLoginExist()
        {
            _userInterface.NewPage();

            _userInterface.ShowData("Login exist!");

            _userInterface.WaitForUser();
        }

        public void ShowLoginWrong()
        {
            _userInterface.NewPage();

            _userInterface.ShowData("Login is wrong!");

            _userInterface.WaitForUser();
        }

        public void ShowPasswordWrong()
        {
            _userInterface.NewPage();

            _userInterface.ShowData("Password is wrong!");

            _userInterface.WaitForUser();
        }

        public void ShowResultOfRegistration(bool result)
        {
            _userInterface.NewPage();

            var resultMessage = new StringBuilder("Registration ");

            if (result)
                resultMessage.Append("successfull!");
            else
                resultMessage.Append("failed!");

            _userInterface.ShowData(resultMessage.ToString());

            _userInterface.WaitForUser();
        }
    }
}
