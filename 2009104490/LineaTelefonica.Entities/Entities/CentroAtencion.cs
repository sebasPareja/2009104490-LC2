using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class CentroAtencion
    {
       
        public int CentroAtencionId { get; private set; }
        public string NombreCentroAtencion { get; set; }
        public int NumeroCentroAtencion{ get; private set; }

        public List<Venta> ListVenta { get; set; }
        public List<Evaluacion>listEvaluacion { get; set; }
       
    }
}
