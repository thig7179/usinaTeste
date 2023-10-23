using System.Reflection.Metadata.Ecma335;
using Usina.Web.Models;
using Usina.Web.Services.IService;
using Usina.Web.Util;

namespace Usina.Web.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/clientes";

        public ClienteService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(HttpClient));
        }
        public async Task<IEnumerable<Cliente>> FindAll()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<Cliente>>();
        }

        public async Task<Cliente> FindClienteByCodigo(long codigo)
        {
            var response = await _client.GetAsync($"{BasePath}/{codigo}");
            return await response.ReadContentAs<Cliente>();
        }

        public async Task<Cliente> FindClienteByName(Cliente model)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> CreateCliente(Cliente model)
        {
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<Cliente>();
            else
                throw new Exception("Something went wrong whe calling API");
        }

        public async Task<Cliente>UpdateCliente(Cliente model)
        {
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<Cliente>();
            else
                throw new Exception("Something went wrong whe calling API");
        }

        public async Task<bool> DeleteClienteByCodigo(long codigo)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{codigo}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception("Something went wrong whe calling API");
        }
    }
}
