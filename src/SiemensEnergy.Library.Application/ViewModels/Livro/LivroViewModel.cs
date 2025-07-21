namespace SiemensEnergy.Library.Application.ViewModels.Livro
{
    public class LivroViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int IdAutor { get; set; }
        public string Autor { get; set; } = string.Empty;
        public int IdGenero { get; set; }
        public string Genero { get; set; } = string.Empty;
    }
}
