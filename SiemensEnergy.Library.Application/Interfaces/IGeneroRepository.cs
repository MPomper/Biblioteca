namespace SiemensEnergy.Library.Application.Interfaces
{
    public interface IGeneroRepository
    {
        Task<int> CreateAsync(Domain.Entities.Genero genero);
        Task<Domain.Entities.Genero?> GetByIdAsync(int id);
        Task<IEnumerable<Domain.Entities.Genero>> GetAllAsync();
        Task UpdateAsync(Domain.Entities.Genero genero);
        Task DeleteAsync(int id);
    }
}
