using Microsoft.EntityFrameworkCore;
using SiemensEnergy.Library.Application.Interfaces;
using SiemensEnergy.Library.Domain.Entities;
using SiemensEnergy.Library.Infrastructure.Data;

namespace SiemensEnergy.Library.Infrastructure.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly ApplicationDbContext _context;

        public GeneroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Genero genero)
        {
            _context.Generos.Add(genero);
            await _context.SaveChangesAsync();
            return genero.Id;
        }

        public async Task UpdateAsync(Genero genero)
        {
            _context.Generos.Update(genero);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero is not null)
            {
                _context.Generos.Remove(genero);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Genero?> GetByIdAsync(int id)
        {
            return await _context.Generos
                        .Include(a => a.Livros)
                        .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Genero>> GetAllAsync()
        {
            return await _context.Generos
                    .Include(a => a.Livros)
                    .ToListAsync();
        }
    }
}