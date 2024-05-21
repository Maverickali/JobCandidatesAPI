using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterDomainServices(this IServiceCollection services, Type program)
        {
        }
    }
}