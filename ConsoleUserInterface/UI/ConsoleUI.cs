using MainComponents.Interfaces.UI;

namespace ConsoleUserInterface.UI
{
    public class ConsoleUI : IUserInterface
    {
        public string GetData()
        {
            string data = Console.ReadLine();

            return data;
        }

        public void ShowData(string text)
        {
            Console.WriteLine(text);
        }
        public void ShowError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(text);

            Console.ResetColor();
        }
        public void NewPage()
        {
            Console.Clear();
        }
        public void WaitForUser()
        {
            ShowData("\n\nEnter anything");

            Console.ReadLine();
        }
    }
}
