using Microsoft.EntityFrameworkCore;
using SportXExame.Config;
using SportXExame.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportXExame.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {

        private readonly Context _context;

        public TelefoneRepository(Context context)
        {
            _context = context;
        }

        public async Task<Telefone> Create(Telefone telefone)
        {
            _context.telefone.Add(telefone);
            await _context.SaveChangesAsync();

            return telefone;
        }

        public async Task Delete(int id)
        {
            var telefoneToDelete = await _context.telefone.FindAsync(id);
            _context.telefone.Remove(telefoneToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Telefone>> Get()
        {
            return await _context.telefone.ToListAsync();

        }

        public async Task<Telefone> Get(int id)
        {
            return await _context.telefone.FindAsync(id);
        }

        public async Task Update(Telefone telefone)
        {
            _context.Entry(telefone).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }


}

