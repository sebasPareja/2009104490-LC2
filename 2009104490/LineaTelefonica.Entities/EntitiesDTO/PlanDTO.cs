using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.EntitiesDTO
{
    public class PlanDTO
    {
        
        public int PlanId { get; set; }
        public string Descripcion { get; set; }
        public int TipoPlanId { set; get; }

    }
}
