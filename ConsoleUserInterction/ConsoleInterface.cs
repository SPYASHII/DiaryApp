using MainComponents.Interfaces.UI;

namespace ConsoleUI
{
    public class ConsoleInterface : IUserInterface
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
    }
}
