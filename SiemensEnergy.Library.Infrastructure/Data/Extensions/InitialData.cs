using SiemensEnergy.Library.Domain.Entities;

namespace SiemensEnergy.Library.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static IEnumerable<Genero> Customers =>
        new List<Genero>
        {
            new Genero { Descricao = "Romance"},
            new Genero { Descricao = "Drama" },
            new Genero { Descricao = "Ficção Científica"}
        };
    }
}
