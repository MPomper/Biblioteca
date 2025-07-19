namespace SiemensEnergy.Library.Domain.Entities
{
    public class Autor
    {
        #region Properties

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<Livro> Livros { get; set; } = new List<Livro>();

        #endregion

        #region Constructor

        public Autor() {}

        public Autor(int id)
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
