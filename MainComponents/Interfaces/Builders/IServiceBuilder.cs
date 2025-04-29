using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MainComponents.Interfaces.Builders
{
    public interface IServiceBuilder
    {
        ServiceProvider BuildServices();
    }
}
