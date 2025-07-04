﻿using MainComponents.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Interfaces.UI
{
    public interface IAuthUI : IOutput
    {
        AuthChoises GetAuthChoise();
        string GetLoginFromUser();
        string GetPasswordFromUser();
        void ShowLoginExist();
        void ShowLoginWrong();
        void ShowPasswordWrong();
        void ShowResultOfRegistration(bool result);
    }
}
