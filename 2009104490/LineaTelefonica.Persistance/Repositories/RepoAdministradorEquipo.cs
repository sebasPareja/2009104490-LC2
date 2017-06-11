using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LineaTelefonica.Entities.Entities;
using LineaTelefonica.Entities.IRepository;
using LineaTelefonica.Persistance;

namespace LineaTelefonica.Persistance.Repositories
{
    public class RepoAdministradorEquipo : Repository<AdministradorEquipo>, IRepoAdministradorEquipo
    {

        public RepoAdministradorEquipo(LineaTelefonicaDbContext context)
            : base(context)
        {
        }

    }
}
