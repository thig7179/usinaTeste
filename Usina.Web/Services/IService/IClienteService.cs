using Usina.Web.Models;

namespace Usina.Web.Services.IService
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> FindAll();
        Task<Cliente> FindClienteByCodigo(long codiogo);
        Task<Cliente> FindClienteByName(Cliente model);
        Task<Cliente> CreateCliente(Cliente model);
        Task<Cliente> UpdateCliente(Cliente model);
        Task<bool> DeleteClienteByCodigo(long codigo);
    }
}
