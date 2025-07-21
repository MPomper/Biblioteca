using SiemensEnergy.Library.Domain.Entities;

namespace SiemensEnergy.Library.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static IEnumerable<Autor> Autores =>
        new List<Autor>
        {
            new Autor { Id = 1, Nome = "Machado de Assis"},
            new Autor { Id = 2, Nome = "William Shakespeare" },
            new Autor { Id = 3, Nome = "Clarice Linspector"},
            new Autor { Id = 4, Nome = "Jorge Amado"},
            new Autor { Id = 5, Nome = "George Orwell"}
        };

        public static IEnumerable<Genero> Generos =>
        new List<Genero>
        {
            new Genero { Id = 1, Descricao = "Romance"},
            new Genero { Id = 2, Descricao = "Drama" },
            new Genero { Id = 3, Descricao = "Ficção Científica"},
            new Genero { Id = 4, Descricao = "Sátira"}
        };

        public static IEnumerable<Livro> Livros =>
        new List<Livro>
        {
            new Livro { Id = 1, Titulo = "Memórias Póstumas de Brás Cubas", IdAutor = 1, IdGenero = 1 },
            new Livro { Id = 2, Titulo = "A revolução dos bichos", IdAutor = 5, IdGenero = 4 }
        };
    }
}
