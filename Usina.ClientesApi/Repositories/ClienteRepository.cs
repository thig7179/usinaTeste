using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Usina.ClientesApi.Data.ValueObject;
using Usina.ClientesApi.Models;
using Usina.ClientesApi.Models.Context;

namespace Usina.ClientesApi.Repositories
{
    public class ClienteRepository : IClientesRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public ClienteRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClienteVO>> FindAll()
        {
            List <Cliente> clientes = await _context.Clientes.ToListAsync();
            return _mapper.Map<List<ClienteVO>>(clientes);
        }

        public async Task<ClienteVO> FindByCodigo(long codigo)
        {
            Cliente cliente = 
                await _context.Clientes.Where(c => c.Codigo == codigo)
                .FirstOrDefaultAsync() ?? new Cliente();
            return _mapper.Map<ClienteVO>(cliente);
        }

        public async Task<ClienteVO> Create(ClienteVO vo)
        {
            Cliente cliente = _mapper.Map<Cliente>(vo);
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClienteVO>(cliente);
        }

        public async Task<ClienteVO> Update(ClienteVO vo)
        {
            Cliente cliente = _mapper.Map<Cliente>(vo);
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClienteVO>(cliente);
        }   

        public async Task<bool> Delete(long codigo)
        {
            try
            {
                Cliente cliente =
                await _context.Clientes.Where(c => c.Codigo == codigo)
                .FirstOrDefaultAsync() ?? new Cliente(); 
                if(cliente == null) return false;
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
