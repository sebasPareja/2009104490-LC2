using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.EntitiesDTO
{
    public class LineaTelefonicaDTO
    {
        
        public int NumeroLineaTelefonica { get; set; }
        public int LineaTelefonicaId { get; set; }
        public int AdministradorLineaId { set; get; }
        public int TipoLineaId { set; get; }
    }
}
