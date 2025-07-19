using Microsoft.EntityFrameworkCore;
using SiemensEnergy.Library.Application.Interfaces;
using SiemensEnergy.Library.Domain.Entities;
using SiemensEnergy.Library.Infrastructure.Data;

namespace SiemensEnergy.Library.Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly ApplicationDbContext _context;

        public LivroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
            return livro.Id;
        }

        public async Task UpdateAsync(Livro livro)
        {
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro is not null)
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Livro?> GetByIdAsync(int id)
        {
            return await _context.Livros.Include(l => l.Autor).Include(l => l.Genero).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Livro?>> GetByFiltroAsync(Livro filtro)
        {
            return await _context.Livros
                                .Include(l => l.Autor)
                                .Include(l => l.Genero)
                                .Where(l =>
                                    (string.IsNullOrEmpty(filtro.Titulo) || l.Titulo.Contains(filtro.Titulo)) &&
                                    (filtro.IdGenero == 0 || l.IdGenero == filtro.IdGenero) &&
                                    (filtro.IdAutor == 0 || l.IdAutor == filtro.IdAutor)
                                )
                                .ToListAsync();
        }

        public async Task<IEnumerable<Livro>> GetAllAsync()
        {
            return await _context.Livros.Include(l => l.Autor).Include(l => l.Genero).ToListAsync();
        }
    }
}