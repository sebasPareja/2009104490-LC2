using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class LineaTelefonica
    {
        
        public int NumeroLineaTelefonica { get; set; }
        public int LineaTelefonicaId { get; set; }
        public List<Venta> ListaVenta { set; get; }
        public List<Evaluacion> listEvaluacion { get; set; }

        public AdministradorLinea AdministradorLinea { set; get; }
        public int AdministradorLineaId { set; get; }


        public int TipoLineaId { set; get; }
        public TipoLinea TipoLinea { set; get; }
    }
}
