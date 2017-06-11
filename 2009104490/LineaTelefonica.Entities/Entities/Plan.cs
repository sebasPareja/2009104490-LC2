using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class Plan
    {
        
        public int PlanId { get; set; }
        public string Descripcion { get; set; }
        public List<Evaluacion> listEvaluacion { get; set; }

        public TipoPlan TipoPlan { set; get; }
        public int TipoPlanId { set; get; }

    }
}
