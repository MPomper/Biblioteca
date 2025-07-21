namespace SiemensEnergy.Library.Domain.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;

        public int IdAutor { get; set; }
        public Autor Autor { get; set; } = null!;

        public int IdGenero { get; set; }
        public Genero Genero { get; set; } = null!;
    }
}
