using Microsoft.Extensions.DependencyInjection;
using MainComponents.Interfaces.DB;
using ServiceBuilders;
using MainComponents.Interfaces.Builders;

namespace DiaryApp
{
    internal class Program
    {
        static void Main()
        {
            IServiceBuilder builder = new ServiceBuilder();

            var provider = builder.BuildServices();

            var db = provider.GetService<IDatabaseAccess>();

            Console.WriteLine(db);
        }
    }
}
