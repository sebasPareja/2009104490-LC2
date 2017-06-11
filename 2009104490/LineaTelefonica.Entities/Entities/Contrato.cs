using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class Contrato
    {
        public String NumeroContrato { set; get; }
        public int ContratoId { get; set; }
        public List<Venta> ListaVenta { set; get; }
    

    }
}
