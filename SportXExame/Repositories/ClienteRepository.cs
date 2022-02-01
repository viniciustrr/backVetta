using Microsoft.EntityFrameworkCore;
using SportXExame.Config;
using SportXExame.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportXExame.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly Context _context;

        public ClienteRepository(Context context)
        {
            _context = context;
        }

        public async Task<Cliente> Create(Cliente cliente)
        {
            _context.cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task Delete(int id)
        {
            var clientToDelete = await _context.cliente.FindAsync(id);
            _context.cliente.Remove(clientToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _context.cliente.ToListAsync();
            
        }

        public async Task<Cliente> Get(int id)
        {
            return await _context.cliente.Include(c => c.telefones).FirstAsync(c => c.id == id) ;
        }

        public async Task Update(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
