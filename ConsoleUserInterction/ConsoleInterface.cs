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

        public string GetData(string text)
        {
            ShowData(text);

            return GetData();
        }

        public void ShowData(string text)
        {
            Console.WriteLine(text);
        }
    }
}
