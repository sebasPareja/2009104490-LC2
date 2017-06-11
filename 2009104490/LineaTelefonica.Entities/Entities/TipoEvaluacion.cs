using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class TipoEvaluacion
    {
        public String NombreTipoEvaluacion { get; set; }
        public int TipoEvaluacionId { get; set; }
        public List<Evaluacion> listEvaluacion { set; get; }

    }
}
