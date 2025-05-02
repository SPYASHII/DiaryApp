using MainComponents.Interfaces.Controllers;
using MainComponents.Interfaces.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainComponents.Enums;
using MainComponents.Models;

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
            bool loaded = _mainDataController.LoadDiary();

            if (loaded)
            {
                MainScenario();
            }

        }
        void MainScenario()
        {
            bool quit = false;

            do
            {
                string text = _mainUI.GetTextForDateOrChoise(DateTime.Now, out var choise);

                HandleChoise(choise, text, ref quit);

            } while (!quit);

            _mainDataController.ClearCurrentData();
        }
        void HandleChoise(MainChoises choise, string text, ref bool quit)
        {
            switch (choise)
            {
                case MainChoises.Data:
                    ShowDataScenario();
                    break;
                case MainChoises.Quit:
                    quit = true;
                    break;
                case MainChoises.None:
                default:
                    CreateAndSaveEntry(text);
                    break;
            }
        }
        void ShowDataScenario()
        {
            if (_mainDataController.GetCurrentDiary(out var diary))
            {
                _mainUI.ShowEntries(diary.GetEntries());
            }
        }
        void CreateAndSaveEntry(string text)
        {
            if (_mainDataController.GetCurrentDiary(out var diary))
            {
                var entry = new Entry(DateTime.Now, text);

                diary.Add(entry);

                bool saved = _mainDataController.SaveDiaryData();

                _mainUI.ShowResultOfEntrySaving(saved);
            }
            else
            {
                //HACK: Пересмотреть решение
                _mainUI.ShowError("Something wrong with diary!");
            }
        }
    }
}
