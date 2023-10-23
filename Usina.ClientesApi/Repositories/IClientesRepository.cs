using Usina.ClientesApi.Data.ValueObject;

namespace Usina.ClientesApi.Repositories
{
    public interface IClientesRepository
    {
        Task<IEnumerable<ClienteVO>> FindAll();
        Task<ClienteVO> FindByCodigo(long codigo);
        Task<ClienteVO> Create(ClienteVO vo);
        Task<ClienteVO> Update(ClienteVO vo);
        Task<bool> Delete(long codigo);
    }
}
