using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class Provincia
    {
        public List<Distrito> ListDistrito { set; get; }
        public List<Ubigeo> ListUbigeo { set; get; }
        public String NombreProvincia { set; get; }
        public int ProvinciaId { get; set; }

        public int DepartamentoId { set; get; }
        public Departamento Departamento { set; get; }
                


    }
}
