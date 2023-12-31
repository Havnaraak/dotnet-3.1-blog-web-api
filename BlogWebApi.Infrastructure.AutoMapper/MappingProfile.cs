using AutoMapper;
using BlogWebApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BlogWebApi.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(typeof(IMapTo<>).Assembly);
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var assemblyTypes = assembly.GetExportedTypes();

            AddMappingForTypes(this, assemblyTypes, typeof(IMapFrom<>));
            AddMappingForTypes(this, assemblyTypes, typeof(IMapTo<>));
        }

        private static void AddMappingForTypes(Profile profile, IEnumerable<Type> types, Type interfaceType)
        {
            var filteredTypes = types
                .Where(t => HasInterface(t, interfaceType))
                .Where(t => t.BaseType == null || !HasInterface(t.BaseType, interfaceType));

            foreach(var type in filteredTypes)
            {
                AddMappingForType(profile, type, interfaceType.Name);
            }
        }

        private static void AddMappingForType(Profile profile, Type type, string interfaceName)
        {
            const string methodName = "Mapping";
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod(methodName) ?? type.GetInterface(interfaceName)?.GetMethod(methodName);
            methodInfo?.Invoke(instance, new object[] { profile });
        }

        private static bool HasInterface(Type sourceType, Type interfaceType)
        {
            return sourceType.GetInterfaces()
                .Any(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == interfaceType);
        }
    }
}
