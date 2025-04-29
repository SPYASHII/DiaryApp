using System.IO;
using System;
using MainComponents.Interfaces.Builders;
using MainComponents.Interfaces.DB;
using MainComponents.Interfaces.Constants;
using MainComponents.Constants;

using JsonDatabase.Models;
using JsonDatabase;

using SerializationDatabase;
using SerializationDatabase.Interfaces;

using Microsoft.Extensions.DependencyInjection;
using MainComponents.Interfaces.Controllers;
using MainComponents.Controllers;
using MainComponents.Interfaces.UI;
using MainComponents.Interfaces.Converters;
using MainComponents.Controllers;
using MainComponents.Converters;
using ConsoleUI;

namespace ServiceBuilders
{
    public class ServiceBuilder : IServiceBuilder
    {
        private IServiceCollection _services;
        public ServiceBuilder()
        {
            _services = new ServiceCollection();
        }
        public ServiceProvider BuildServices()
        {
            AddConverters();

            AddUIServices();
            AddDbServices();

            AddControllers();

            return _services.BuildServiceProvider();
        }
        private void AddDbServices()
        {
            _services.AddSingleton<IDatabasePath, Pathes>()
                .AddSingleton<ISerializationDBAccess<JsUser, JsDiary>, JsonDB>()
                .AddSingleton<IDatabaseAccess, SerializationDB<JsUser, JsDiary>>();
        }
        private void AddConverters()
        {
            _services.AddSingleton<ITextToChoisesConverter, ChoiseConverter>();

            _services.AddSingleton<IDataConverter<JsUser, JsDiary>, JsonDataConverter>();
        }
        private void AddUIServices()
        {
            _services.AddSingleton<IUserInterface, ConsoleInterface>();
        }
        private void AddControllers()
        {
            _services.AddSingleton<IDataController, DataController>()
                .AddSingleton<IAuthDataController, DataController>()
                .AddSingleton<IMainDataController, DataController>();

            _services.AddSingleton<IUserInterfaceController, UIController>()
                .AddSingleton<IMainUI, UIController>()
                .AddSingleton<IAuthUI, UIController>();

            _services.AddSingleton<IAuthController, AuthController>();

            _services.AddSingleton<IMainController, MainController>();
        }
    }
}
