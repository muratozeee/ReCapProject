using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        //it is loading general dependencies.
        //it loads  with the service collection signature.
        void Load(IServiceCollection serviceCollection);

    }
}
