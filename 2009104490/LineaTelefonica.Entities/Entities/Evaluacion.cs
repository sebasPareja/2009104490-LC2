using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class Evaluacion
    {
        
        public int NumeroEvaluacion{ set; get; }
        public int NumeroTurno { get;  set; }   
        public int EvaluacionId { get; set; }

        public TipoEvaluacion TipoEvaluacion { set; get; }
        public int TipoEvaluacionId { set; get; }

        public int EstadoEvaluacionId { set; get; }
        public EstadoEvaluacion EstadoEvaluacion { set; get; }

        public List<Venta> ListaVenta { set; get; }

        public int CentroAtencionId { set; get; }
        public CentroAtencion CentroAtencion { set; get; }

        public LineaTelefonica LineaTelefonica { set; get; }
        public int LineaTelefonicaId { set; get; }

        public Plan Plan { set; get; }
        public int PlanId { set; get; }


        public int TrabajadorId { set; get; }
        public Trabajador Trabajador { set; get; }

    }
}
