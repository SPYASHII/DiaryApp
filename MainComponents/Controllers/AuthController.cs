using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MainComponents.Enums;
using MainComponents.Interfaces.Controllers;
using MainComponents.Interfaces.UI;
using MainComponents.Models;

namespace MainComponents.Controllers
{
    public class AuthController : IAuthController
    {
        private readonly IAuthDataController _authDataController;
        private readonly IAuthUI _authUI;
        public AuthController(IAuthDataController dataController, IAuthUI authUI)
        {
            _authDataController = dataController;
            _authUI = authUI;
        }

        public bool StartAuthentication()
        {
            bool result = false;

            var choise = _authUI.GetAuthChoise();

            switch (choise)
            {
                case AuthChoises.Login:
                    result = Login();
                    break;
                case AuthChoises.Registration:
                    Registration();
                    break;
                case AuthChoises.None:
                default:
                    break;
            }

            return result;
        }
        private void Registration()
        {
            string login = _authUI.GetLoginFromUser();

            bool exist = _authDataController.UserExists(login);

            if (!exist)
            {
                string password = _authUI.GetPasswordFromUser();

                bool saved = _authDataController.CreateUser(login, password);

                _authUI.ShowResultOfRegistration(saved);
            }
            else
            {
                _authUI.ShowLoginExist();
            }
        }
        private bool Login()
        {
            bool loggedIn = false;
            
            if (CheckLogin(out string login))
            {
                _authDataController.LoadUser(login);

                if (!CheckPassword())
                {
                    _authUI.ShowPasswordWrong();
                    _authDataController.ClearCurrentData();
                }
                else
                {
                    loggedIn = true;
                }
            }
            else
            {
                _authUI.ShowLoginWrong();
            }
            
            return loggedIn;
        }
        bool CheckLogin(out string login)
        {
            login = _authUI.GetLoginFromUser();

            bool exist = _authDataController.UserExists(login);

            return exist;
        }
        bool CheckPassword()
        {
            string password = _authUI.GetPasswordFromUser();

            bool correct = false;

            if (_authDataController.GetCurrentUser(out var user))
            {
                correct = user?.Password == password;
            }

            return correct;
        }
    }
}
