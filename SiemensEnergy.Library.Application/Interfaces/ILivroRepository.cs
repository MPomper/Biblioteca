using SiemensEnergy.Library.Domain.Entities;

namespace SiemensEnergy.Library.Application.Interfaces
{
    public interface ILivroRepository
    {
        Task<int> CreateAsync(Domain.Entities.Livro livro);
        Task<Domain.Entities.Livro?> GetByIdAsync(int id);
        Task<IEnumerable<Domain.Entities.Livro?>> GetByFiltroAsync(Domain.Entities.Livro filtro);
        Task<IEnumerable<Domain.Entities.Livro>> GetAllAsync();
        Task UpdateAsync(Domain.Entities.Livro livro);
        Task DeleteAsync(int id);
    }
}