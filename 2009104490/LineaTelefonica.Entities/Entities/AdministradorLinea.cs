using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class AdministradorLinea
    {
        public List<LineaTelefonica> LineaTelefonica { set; get; }
        public int AdministradorLineaId { get; set; }
        public String NombreAdministradorLinea { set; get; }

    }
}
