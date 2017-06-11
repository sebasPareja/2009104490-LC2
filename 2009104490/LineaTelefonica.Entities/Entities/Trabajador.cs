using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class Trabajador
    {

        public int TrabajadorId { get;  set; }
        public int NombreTrabajador { get;  set; }
        public List<Evaluacion> listEvaluacion { get; set; }
        public List<Venta> ListVenta { get; set; }

        public int TipoTrabajadorId{set;get;}
        public TipoTrabajador TipoTrabajador { set; get; }


    }
}
