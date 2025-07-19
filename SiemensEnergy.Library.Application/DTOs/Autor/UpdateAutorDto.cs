using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiemensEnergy.Library.Application.DTOs.Autor
{
    public class UpdateAutorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
