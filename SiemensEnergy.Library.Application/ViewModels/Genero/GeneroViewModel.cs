namespace SiemensEnergy.Library.Application.ViewModels.Genero
{
    public class GeneroViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public List<string> Livros { get; set; } = new();
    }
}
