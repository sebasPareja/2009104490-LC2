using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineaTelefonica.Entities.Entities
{
    public class Ubigeo
    {
        public Departamento Departamento { set; get; }
        public int DepartamentoId { set; get; }

        public Provincia Provincia { set; get; }
        public int ProvinciaId { set; get; }

        public Distrito Distrito { set; get; }
        public int DistritoId { set; get; }

        public int UbigeoId { get; set; }
        public String CodigoUbigeo { set; get; }


    }
}
