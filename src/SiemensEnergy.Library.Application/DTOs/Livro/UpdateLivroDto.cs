using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiemensEnergy.Library.Application.DTOs.Livro
{
    public class UpdateLivroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int IdAutor { get; set; }
        public int IdGenero { get; set; }
    }
}
