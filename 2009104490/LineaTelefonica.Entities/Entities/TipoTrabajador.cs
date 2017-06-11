using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class TipoTrabajador
    {
        public int NombreTipoTrabajador { get; set; }
        public int TipoTrabajadorId { get; set; }
        public List<Trabajador> ListTrabajador { set; get; }

    }
}
