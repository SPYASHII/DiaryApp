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
            AddDbServices();

            return _services.BuildServiceProvider();
        }
        private void AddDbServices()
        {
            _services.AddSingleton<IDatabasePath, Pathes>()
                .AddSingleton<ISerializationDBAccess<JsUser, JsDiary>, JsonDB>()
                .AddSingleton<IDataConverter<JsUser, JsDiary>, JsonDataConverter>()
                .AddSingleton<IDatabaseAccess, SerializationDB<JsUser, JsDiary>>();
        }
    }
}
