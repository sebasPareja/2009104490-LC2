using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class TipoPlan
    {
        public String NombreTipoPlan { set; get; }
        public int TipoPlanId { get; set; }
        public List<Plan> ListPlan { get; set; }
    }
}
