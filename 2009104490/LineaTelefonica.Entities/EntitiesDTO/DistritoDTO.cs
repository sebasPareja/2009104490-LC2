using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.EntitiesDTO
{
    public class DistritoDTO
    {
        public String NombreDistrito { get; set; }
        public int DistritoId { get; set; }     
        public int ProvinciaId { set; get; }

        
    }
}
