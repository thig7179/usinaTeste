using AutoMapper;
using Usina.ClientesApi.Data.ValueObject;
using Usina.ClientesApi.Models;

namespace Usina.ClientesApi.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        {
            var mappingConfig =  new MapperConfiguration(
                config =>
                {
                    config.CreateMap<ClienteVO, Cliente>();
                    config.CreateMap<Cliente, ClienteVO>();
                });
            return mappingConfig;
        }
    }
}
