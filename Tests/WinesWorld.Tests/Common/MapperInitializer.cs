using System.Reflection;
using WinesWorld.Data.Models;
using WinesWorld.Services.Mapping;
using WinesWorld.Services.Models;

namespace WinesWorld.Tests.Common
{
    public static class MapperInitializer
    {
        public static void InitializeMapping()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(WineServiceModel).GetTypeInfo().Assembly,
                typeof(Wine).GetTypeInfo().Assembly);
        }
    }
}
