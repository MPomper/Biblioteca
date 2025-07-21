namespace SiemensEnergy.Library.Application.Interfaces
{
    public interface IAutorRepository
    {
        Task<int> CreateAsync(Domain.Entities.Autor autor);
        Task<Domain.Entities.Autor?> GetByIdAsync(int id);
        Task<IEnumerable<Domain.Entities.Autor>> GetAllAsync();
        Task UpdateAsync(Domain.Entities.Autor autor);
        Task DeleteAsync(int id);
    }
}
