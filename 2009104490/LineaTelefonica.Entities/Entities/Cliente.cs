using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public String NombreCliente { set; get; }
        public String DNI { set; get; }
        public TipoCliente TipoCliente { get; set; }
        public List<Venta> ListaVenta { set; get; }
    }
}
