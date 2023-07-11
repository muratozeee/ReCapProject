using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //we are using for dependency and this=extension meaning
        //Also in this system adding all injections as a 1 framework
        public static IServiceCollection AddDependencyResolvers
            (this  IServiceCollection serviceCollection, ICoreModule[] modules )
        {
            //it means we can add more then 1 module in this system.
            foreach (var module in modules)
            {
                module.Load(serviceCollection);

            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
