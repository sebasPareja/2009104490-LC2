using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LineaTelefonica.Entities.IRepository;
using LineaTelefonica.Entities.Entities;

namespace LineaTelefonica.Persistance.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly LineaTelefonicaDbContext _Context;
        private static UnityOfWork _Instance;
        private static readonly object _Lock = new object();

        public IRepoAdministradorEquipo AdministradorEquipo {set;get;}
        public IRepoAdministradorLinea AdministradorLinea {set;get;}
        public IRepoCentroAtencion CentroAtencion {set;get;}
        public IRepoCliente Cliente {set;get;}
        public IRepoContrato Contrato {set;get;}
        public IRepoDepartamento Departamento {set;get;}
        public IRepoDireccion Direccion {set;get;}
        public IRepoDistrito Distrito {set;get;}
        public IRepoEquipoCelular EquipoCelular {set;get;}
        public IRepoEstadoEvaluacion EstadoEvaluacion { set; get; }
        public IRepoEvaluacion Evaluacion {set;get;}
        public IRepoLineaTelefonica LineaTelefonica {set;get;}
        public IRepoPlan Plan {set;get;}
        public IRepoProvincia Provincia {set;get;}
        public IRepoTipoEvaluacion TipoEvaluacion {set;get;}
        public IRepoTipoLinea TipoLinea {set;get;}
        public IRepoTipoPago TipoPago {set;get;}
        public IRepoTipoPlan TipoPlan {set;get;}
        public IRepoTipoTrabajador TipoTrabajador {set;get;}
        public IRepoTrabajador Trabajador {set;get;}
        public IRepoUbigeo Ubigeo {set;get;}
        public IRepoVenta Venta { set; get; }


        public UnityOfWork()
        {
            _Context = new LineaTelefonicaDbContext();

            AdministradorEquipo = new RepoAdministradorEquipo(_Context);
            AdministradorLinea = new RepoAdministradorLinea(_Context);
            CentroAtencion = new RepoCentroAtencion(_Context);
            Cliente = new RepoCliente(_Context);
            Contrato = new RepoContrato(_Context);
            Departamento = new RepoDepartamento(_Context);
            Direccion = new RepoDireccion(_Context);
            Distrito = new RepoDistrito(_Context);
            EquipoCelular = new RepoEquipoCelular(_Context);
            EstadoEvaluacion = new RepoEstadoEvaluacion(_Context);
            Evaluacion = new RepoEvaluacion(_Context);
            LineaTelefonica = new RepoLineaTelefonica(_Context);
            Provincia = new RepoProvincia(_Context);
            TipoEvaluacion = new RepoTipoEvaluacion(_Context);
            TipoLinea = new RepoTipoLinea(_Context);
            TipoPago = new RepoTipoPago(_Context);
            TipoPlan = new RepoTipoPlan(_Context);
            TipoTrabajador = new RepoTipoTrabajador(_Context);
            Trabajador = new RepoTrabajador(_Context);
            Ubigeo = new RepoUbigeo(_Context);
            Venta = new RepoVenta(_Context);

        }


        public static UnityOfWork Instance
        {
            get
            {
                lock (_Lock)
                {
                    if (_Instance == null)
                        _Instance = new UnityOfWork();
                }
                return _Instance;
            }
        }



        
        public void Dispose()
        {
            _Context.Dispose();
        }

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }

    }
}
