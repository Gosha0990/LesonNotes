using AutoMapper;
using Neotes.Application.Common.Mappings;
using System;
using System.Linq;
using System.Reflection;

namespace Neotes.Application.Interfaces
{
    class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) =>
            ApplyMappingsFromAssembly(assembly);
        

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                 .Where(type => type.GetInterfaces()
                     .Any(i => i.IsGenericType &&
                     i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                 .ToList();
            foreach(var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
