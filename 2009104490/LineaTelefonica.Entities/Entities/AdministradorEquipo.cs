using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class AdministradorEquipo
    {
        public List<EquipoCelular> ListEquipoCelular { set; get; }
        public int AdministradorEquipoId { get; set; }
        public String NombreAdministradorEquipo { set; get; }
        
    }
}
