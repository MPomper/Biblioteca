using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiemensEnergy.Library.Application.DTOs.Genero
{
    public class UpdateGeneroDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
