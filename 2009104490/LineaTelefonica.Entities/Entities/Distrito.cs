using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class Distrito
    {
        public String NombreDistrito { get; set; }
        public int DistritoId { get; set; }
        public List<Ubigeo> ListUbigeo { set; get; }
        public Provincia Provincia { set; get; }
        public int ProvinciaId { set; get; }

        
    }
}
