using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class EstadoEvaluacion
    {
        public String NombreEstadoEvaluacion{set;get;}
        public int EstadoEvaluacionId { get; set; }
        public List<Evaluacion> ListEvaluacion { set; get; }

    }
}
