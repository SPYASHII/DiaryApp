using MainComponents.Enums;
using MainComponents.Interfaces.Controllers;
using MainComponents.Interfaces.Converters;
using MainComponents.Interfaces.UI;
using MainComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Controllers
{
    public class UIController : IUserInterfaceController
    {
        private ITextToAuthChoisesConverter _authConverter;
        private ITextToMainChoisesConverter _mainConverter;

        private IUserInterface _userInterface;
        public UIController(IUserInterface userInterface,ITextToChoisesConverter choiseConverter)
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

            _userInterface.ShowData(date.Date.ToString() + "\n");
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
        }

        public void ShowEntrySaved()
        {
            _userInterface.NewPage();

            _userInterface.ShowData("Entry saved!");

            WaitForUser();
        }
        //этот метод не должен быть здесь, временное решение
        private void WaitForUser()
        {
            _userInterface.ShowData("\n\nEnter anything");

            //TODO: Добавить в IUserInterface метод WaitForUser();
            _userInterface.GetData();
        }

        public void ShowError(string text)
        {
            _userInterface.ShowError(text);
        }

        public void ShowLoginExist()
        {
            _userInterface.NewPage();

            _userInterface.ShowData("Login exist!");

            WaitForUser();
        }

        public void ShowLoginWrong()
        {
            _userInterface.NewPage();

            _userInterface.ShowData("Login is wrong!");

            WaitForUser();
        }

        public void ShowPasswordWrong()
        {
            _userInterface.NewPage();

            _userInterface.ShowData("Password is wrong!");

            WaitForUser();
        }

        public void ShowRegistrationCompleted()
        {
            _userInterface.NewPage();

            _userInterface.ShowData("Registration successfull!");

            WaitForUser();
        }
    }
}
