using SportXExame.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportXExame.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> Get();
        Task<Cliente> Get(int id);

        Task<Cliente> Create(Cliente cliente);

        Task Update(Cliente cliente);
        Task Delete(int id);
    }
}
