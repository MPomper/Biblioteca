namespace SiemensEnergy.Library.Application.ViewModels.Autor
{
    public class AutorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<string> Livros { get; set; } = new();
    }
}
