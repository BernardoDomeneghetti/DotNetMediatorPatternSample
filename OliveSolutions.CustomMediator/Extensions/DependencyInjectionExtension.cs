using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OliveSolutions.CustomMediator.Abstractions;
using OliveSolutions.CustomMediator.Abstractions.Handlers;
using OliveSolutions.CustomMediator.Implementations;

namespace OliveSolutions.CustomMediator.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddCustomMediator(this IServiceCollection services, string[] namespaces)
        {
            var assemblies = ResolveAssemblies(namespaces);
            services.AddSingleton<IMediator, Mediator>();

            RegisterHandlers(services, assemblies, typeof(IRequestHandler<,>));
            RegisterHandlers(services, assemblies, typeof(INotificationHandler<>));
        }

        private static void RegisterHandlers(IServiceCollection services, Assembly[] assemblies, Type handlerInterface)
        {
            var types = assemblies.SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract)
                .ToList();

            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces()
                    .Where(
                        i => i.IsGenericType
                            && i.GetGenericTypeDefinition() == handlerInterface
                    );

                foreach (var @interface in interfaces)
                {
                    services.AddTransient(@interface, type);
                }
            }
        }
        
        private static Assembly[] ResolveAssemblies(string[] namespaces)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where
                (
                    a =>
                    !a.IsDynamic
                        && !string.IsNullOrWhiteSpace(a.FullName)
                        && namespaces.Any(ns => a.FullName.StartsWith(ns))
                )
                .ToArray();
        }
    }
}

