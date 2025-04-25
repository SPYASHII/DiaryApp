using MainComponents.Interfaces;

namespace ConsoleUserInteraction
{
    public class ConsoleInteraction : IUserInteraction
    {
        public string GetData()
        {
            string data = Console.ReadLine();

            return data;
        }

        public string GetData(string message)
        {
            ShowMessage(message);

            return GetData();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
