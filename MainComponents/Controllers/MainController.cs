using MainComponents.Interfaces.Controllers;
using MainComponents.Interfaces.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Controllers
{
    public class MainController : IMainController
    {
        private readonly IMainDataController _mainDataController;
        private readonly IMainUI _mainUI;
        public MainController(IMainDataController dataController, IMainUI mainUI) 
        {
            _mainDataController = dataController;
            _mainUI = mainUI;
        }
        public void StartMainScenario()
        {
            throw new NotImplementedException();
        }
    }
}
