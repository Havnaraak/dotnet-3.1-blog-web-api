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

        /// <summary>
        /// Responsável por buscar os types disponíveis no assembly da interface de map
        /// </summary>
        /// <param name="assembly">Assembly para ser usado na busca dos types</param>
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var assemblyTypes = assembly.GetExportedTypes();

            AddMappingForTypes(this, assemblyTypes, typeof(IMapFrom<>));
            AddMappingForTypes(this, assemblyTypes, typeof(IMapTo<>));
        }

        /// <summary>
        /// Responsável por percorrer os tipos do assembly e identificar os tipos que herdam da interface de map
        /// </summary>
        /// <param name="profile">Profile do automapper</param>
        /// <param name="types">Lista com types dentro do assembly para varredura</param>
        /// <param name="interfaceType">Tipo da interface que será buscada</param>
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


        /// <summary>
        /// Responsável por criar a instância do tipo e chamar o método Mapping que é reponsável pelo CreateMap
        /// </summary>
        /// <param name="profile">Profile do automapper</param>
        /// <param name="type">Tipo da classe que será adicionada</param>
        /// <param name="interfaceName">Nome da interface para adicionar</param>
        private static void AddMappingForType(Profile profile, Type type, string interfaceName)
        {
            const string methodName = "Mapping";
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod(methodName) ?? type.GetInterface(interfaceName)?.GetMethod(methodName);
            methodInfo?.Invoke(instance, new object[] { profile });
        }

        /// <summary>
        /// Valida se o tipo informado herda a interface de map
        /// </summary>
        /// <param name="sourceType">Tipo para busca da interface</param>
        /// <param name="interfaceType">Tipo da interface para busca</param>
        /// <returns></returns>
        private static bool HasInterface(Type sourceType, Type interfaceType)
        {
            return sourceType.GetInterfaces()
                .Any(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == interfaceType);
        }
    }
}
