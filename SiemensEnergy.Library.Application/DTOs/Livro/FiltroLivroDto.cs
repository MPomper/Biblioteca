using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiemensEnergy.Library.Application.DTOs.Livro
{
    public class FiltroLivroDto
    {
        public string? Titulo { get; set; }
        public int? IdAutor { get; set; }
        public int? IdGenero { get; set; }
    }
}
