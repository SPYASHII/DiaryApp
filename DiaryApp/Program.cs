using Microsoft.Extensions.DependencyInjection;
using MainComponents.Interfaces.DB;
using ServiceBuilders;
using MainComponents.Interfaces.Builders;
using MainComponents.Interfaces.Controllers;

namespace DiaryApp
{
    internal class Program
    {
        static void Main()
        {
            IServiceBuilder builder = new ServiceBuilder();

            var provider = builder.BuildServices();

            var authContr = provider.GetService<IAuthController>();
            var mainContr = provider.GetService<IMainController>();

            if (authContr != null && mainContr != null)
            {
                App app = new App(authContr, mainContr);

                app.Start();
            }
            else
            {
                Console.WriteLine("ERROR");
            }
        }
    }
}
