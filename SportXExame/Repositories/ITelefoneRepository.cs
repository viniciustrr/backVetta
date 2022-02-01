using SportXExame.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportXExame.Repositories
{
    public interface ITelefoneRepository
    {
        Task<IEnumerable<Telefone>> Get();
        Task<Telefone> Get(int id);

        Task<Telefone> Create(Telefone telefone);

        Task Update(Telefone telefone);
        Task Delete(int id);
    }
}
