using MainComponents.Enums;
using MainComponents.Interfaces.Controllers;
using MainComponents.Interfaces.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }
        //Абсолютно отвратительный метод написаный для временной проверки работоспособности программы
        private bool Login()
        {
            bool loggedIn = false;
            
            string login = _authUI.GetLoginFromUser();

            if (!string.IsNullOrEmpty(login))
            {
                bool userExist = _authDataController.UserExists(login);
                
                if (userExist)
                {
                    _authDataController.LoadUser(login);

                    string password = _authUI.GetPasswordFromUser();

                    if (!string.IsNullOrEmpty(password))
                    {
                        if (_authDataController.GetCurrentUser(out var user))
                        {
                            if(user?.Password ==  password)
                                loggedIn = true;
                            else
                            {
                                _authUI.ShowPasswordWrong();
                            }
                        }
                    }
                }
                else
                {
                    _authUI.ShowLoginWrong();
                }
            }

            return loggedIn;
        }
    }
}
