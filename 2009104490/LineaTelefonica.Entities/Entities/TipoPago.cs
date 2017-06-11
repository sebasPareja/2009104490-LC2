using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class TipoPago
    {
        public String NombreTipoPago { set; get; }
        public int TipoPagoId { get; set; }
        public List<Venta> ListVenta { set; get; }
    }
}
