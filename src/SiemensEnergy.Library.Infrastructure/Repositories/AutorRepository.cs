using Microsoft.EntityFrameworkCore;
using SiemensEnergy.Library.Application.Interfaces;
using SiemensEnergy.Library.Domain.Entities;
using SiemensEnergy.Library.Infrastructure.Data;

namespace SiemensEnergy.Library.Infrastructure.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly ApplicationDbContext _context;

        public AutorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
            return autor.Id;
        }

        public async Task UpdateAsync(Autor autor)
        {
            _context.Autores.Update(autor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor is not null)
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Autor?> GetByIdAsync(int id)
        {
            return await _context.Autores
                        .Include(a => a.Livros)
                        .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Autor>> GetAllAsync()
        {
            return await _context.Autores
                    .Include(a => a.Livros)
                    .ToListAsync();
        }
    }
}