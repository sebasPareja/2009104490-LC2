using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class TipoLinea
    {
        public String NombreTipoLinea { set; get; }
        public int TipoLineaId { get; set; }
        public List<LineaTelefonica> ListLineaTelefonica { get; set; }
    }
}
