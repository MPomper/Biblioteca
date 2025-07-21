namespace SiemensEnergy.Library.Domain.Entities
{
    public class Genero
    {
        #region Properties

        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public List<Livro> Livros { get; set; } = new List<Livro>();

        #endregion

        #region Constructor

        public Genero() { }

        public Genero(int id)
        {
            Id = id;
        }

        #endregion

        #region Public Methods

        public void AdicionarLivro(Livro livro)
        {
            Livros.Add(livro);
        }

        #endregion
    }
}
