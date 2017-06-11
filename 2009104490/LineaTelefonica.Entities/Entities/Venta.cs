using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class Venta
    {
        //El centro de atencion atiende varias ventas y evalua a varios clientes
        //Un centro y n ventas

        public String Fecha  { get;  set; }
        public double Monto { get; set; }
        public int VentaId { get;  set; }

        public CentroAtencion CentroAtencion { set; get; }
        public int CentroAtencionId { set; get; }


        public Evaluacion Evaluacion { set; get; }
        public int EvaluacionId { set; get; }

        public int LineaTelefonicaId { set; get; }
        public LineaTelefonica LineaTelefonica { set; get; }

        public int TipoPagoId { set; get; }
        public TipoPago TipoPago { set; get; }

        public Trabajador Trabajador { set; get; }
        public int TrabajadorId { set; get; }
        
    }
}
