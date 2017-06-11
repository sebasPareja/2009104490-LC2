using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class EquipoCelular
    {
        public int NumeroEquipoCelular { get; set; }
        public int EquipoCelularId { get; set; }

        public int AdministradorEquipoId { set; get; }
        public AdministradorEquipo AdministradorEquipo { set; get; }

        public List<Evaluacion> listEvaluacion { get; set; }


    }
}
