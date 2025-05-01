using MainComponents.Interfaces.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MainComponents
{
    public class App
    {
        private readonly IAuthController _authController;
        private readonly IMainController _mainController;
        public App(IAuthController authController, IMainController mainController)
        {
            _authController = authController;
            _mainController = mainController;
        }
        public void Start()
        {
            while (true)
            {
                if(_authController.StartAuthentication())
                    _mainController.StartMainScenario();
            }
        }
    }
}
