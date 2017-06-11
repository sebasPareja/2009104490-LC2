using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.EntitiesDTO
{
    public class EvaluacionDTO
    {
        
        public int NumeroEvaluacion{ set; get; }
        public int NumeroTurno { get;  set; }   
        public int EvaluacionId { get; set; }
        public int TipoEvaluacionId { set; get; }
        public int EstadoEvaluacionId { set; get; }
        public int CentroAtencionId { set; get; }
        public int LineaTelefonicaId { set; get; }
        public int PlanId { set; get; }
        public int TrabajadorId { set; get; }

    }
}
