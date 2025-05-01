using Microsoft.Extensions.DependencyInjection;
using MainComponents.Interfaces.DB;
using MainComponents.Interfaces.Builders;
using MainComponents.Interfaces.Controllers;
using MainComponents;

namespace ConsoleUserInterface
{
    internal class Program
    {
        static void Main()
        {
            IServiceBuilder builder = new ServiceBuilder();

            var provider = builder.BuildServices();

            var authController = provider.GetService<IAuthController>();
            var mainController = provider.GetService<IMainController>();

            App app = new App(authController, mainController);

            app.Start();
        }
    }
}
