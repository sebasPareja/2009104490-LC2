using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LineaTelefonica.Entities.Entities;

namespace LineaTelefonica.Persistance
{
    public class LineaTelefonicaDbContext : DbContext
    {
        public DbSet<AdministradorEquipo> administradorEquipo { get; set; }
        public DbSet<AdministradorLinea> administradorLinea { get; set; }
        public DbSet<CentroAtencion> centroatencion { get; set; }
        public DbSet<Contrato> contrato { get; set; }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Departamento> departamento { get; set; }
        public DbSet<Direccion> direccion { get; set; }
        public DbSet<Distrito> distrito { get; set; }
        public DbSet<EquipoCelular> equipocelular { get; set; }
        public DbSet<Evaluacion> evaluacion { get; set; }
        public DbSet<LineaTelefonica.Entities.Entities.LineaTelefonica> lineatelefonica { get; set; }
        public DbSet<Plan> plan { get; set; }
        public DbSet<Provincia> provincia { get; set; }
        public DbSet<Trabajador> trabajador { get; set; }
        public DbSet<Ubigeo> ubigeo { get; set; }
        public DbSet<Venta> venta { get; set; }

        public LineaTelefonicaDbContext()
			:base("LineasNuevas")
		{

		}


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {




            modelBuilder.Entity<AdministradorEquipo>().ToTable("AdministradorEquipo");
            modelBuilder.Entity<AdministradorEquipo>().HasKey(a => a.AdministradorEquipoId);




            modelBuilder.Entity<AdministradorLinea>().ToTable("AdministradorLinea");
            modelBuilder.Entity<AdministradorLinea>().HasKey(a => a.AdministradorLineaId);


            modelBuilder.Entity<CentroAtencion>().ToTable("CentroAtencion");
            modelBuilder.Entity<CentroAtencion>().HasKey(a => a.CentroAtencionId);


            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Cliente>().HasKey(a => a.ClienteId);


            modelBuilder.Entity<Contrato>().ToTable("Contrato");
            modelBuilder.Entity<Contrato>().HasKey(a => a.ContratoId);


            modelBuilder.Entity<Departamento>().ToTable("Departamento");
            modelBuilder.Entity<Departamento>().HasKey(a => a.DepartamentoId);


            modelBuilder.Entity<Direccion>().ToTable("Direccion");
            modelBuilder.Entity<Direccion>().HasKey(a => a.DireccionId);


            modelBuilder.Entity<Distrito>().ToTable("Distrito");
            modelBuilder.Entity<Distrito>().HasKey(a => a.DistritoId);
            modelBuilder.Entity<Distrito>().HasRequired(v => v.Provincia)
                .WithMany(g => g.ListDistrito)
                .HasForeignKey(v => v.ProvinciaId).WillCascadeOnDelete(false); ;


            modelBuilder.Entity<EquipoCelular>().ToTable("EquipoCelular");
            modelBuilder.Entity<EquipoCelular>().HasKey(a => a.EquipoCelularId);


            modelBuilder.Entity<EstadoEvaluacion>().ToTable("EstadoEvaluacion");
            modelBuilder.Entity<EstadoEvaluacion>().HasKey(a => a.EstadoEvaluacionId);



            modelBuilder.Entity<Evaluacion>().ToTable("Evaluacion");
            modelBuilder.Entity<Evaluacion>().HasKey(a => a.EvaluacionId);
            modelBuilder.Entity<Evaluacion>().HasRequired(v => v.EstadoEvaluacion)
                .WithMany(g => g.ListEvaluacion)
                .HasForeignKey(v => v.EstadoEvaluacionId);
            modelBuilder.Entity<Evaluacion>().HasRequired(v => v.TipoEvaluacion)
                .WithMany(g => g.listEvaluacion)
                .HasForeignKey(v => v.TipoEvaluacionId);
            modelBuilder.Entity<Evaluacion>().HasRequired(v => v.CentroAtencion)
                .WithMany(g => g.listEvaluacion)
                .HasForeignKey(v => v.CentroAtencionId);
            modelBuilder.Entity<Evaluacion>().HasRequired(v => v.LineaTelefonica)
                .WithMany(g => g.listEvaluacion)
                .HasForeignKey(v => v.LineaTelefonicaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Evaluacion>().HasRequired(v => v.Plan)
                .WithMany(g => g.listEvaluacion)
                .HasForeignKey(v => v.PlanId);
            modelBuilder.Entity<Evaluacion>().HasRequired(v => v.Trabajador)
                .WithMany(g => g.listEvaluacion)
                .HasForeignKey(v => v.TrabajadorId);


            modelBuilder.Entity<LineaTelefonica.Entities.Entities.LineaTelefonica>().ToTable("LineaTelefonica");
            modelBuilder.Entity<LineaTelefonica.Entities.Entities.LineaTelefonica>().HasKey(a => a.LineaTelefonicaId);


            modelBuilder.Entity<Plan>().ToTable("Plan");
            modelBuilder.Entity<Plan>().HasKey(a => a.PlanId);
            modelBuilder.Entity<Plan>().HasRequired(v => v.TipoPlan)
                .WithMany(g => g.ListPlan)
                .HasForeignKey(v => v.TipoPlanId);

            modelBuilder.Entity<Provincia>().ToTable("Provincia");
            modelBuilder.Entity<Provincia>().HasKey(a => a.ProvinciaId);
            modelBuilder.Entity<Provincia>().HasRequired(v => v.Departamento)
                .WithMany(g => g.ListProvincia)
                .HasForeignKey(v => v.DepartamentoId).WillCascadeOnDelete(false); ;

            modelBuilder.Entity<TipoEvaluacion>().ToTable("TipoEvaluacion");
            modelBuilder.Entity<TipoEvaluacion>().HasKey(a => a.TipoEvaluacionId);


            modelBuilder.Entity<TipoLinea>().ToTable("TipoLinea");
            modelBuilder.Entity<TipoLinea>().HasKey(a => a.TipoLineaId);


            modelBuilder.Entity<TipoPago>().ToTable("TipoPago");
            modelBuilder.Entity<TipoPago>().HasKey(a => a.TipoPagoId);


            modelBuilder.Entity<TipoPlan>().ToTable("TipoPlan");
            modelBuilder.Entity<TipoPlan>().HasKey(a => a.TipoPlanId);



            modelBuilder.Entity<TipoTrabajador>().ToTable("TipoTrabajador");
            modelBuilder.Entity<TipoTrabajador>().HasKey(a => a.TipoTrabajadorId);


            modelBuilder.Entity<Trabajador>().ToTable("Trabajador");
            modelBuilder.Entity<Trabajador>().HasKey(a => a.TrabajadorId);
            modelBuilder.Entity<Trabajador>().HasRequired(v => v.TipoTrabajador)
                .WithMany(g => g.ListTrabajador)
                .HasForeignKey(v => v.TipoTrabajadorId);


            modelBuilder.Entity<Ubigeo>().ToTable("Ubigeo");
            modelBuilder.Entity<Ubigeo>().HasKey(a => a.UbigeoId);
            modelBuilder.Entity<Ubigeo>().HasRequired(v => v.Departamento)
                .WithMany(g => g.ListUbigeo)
                .HasForeignKey(v => v.DepartamentoId);
            modelBuilder.Entity<Ubigeo>().HasRequired(v => v.Provincia)
                .WithMany(g => g.ListUbigeo)
                .HasForeignKey(v => v.ProvinciaId);
            modelBuilder.Entity<Ubigeo>().HasRequired(v => v.Distrito)
                .WithMany(g => g.ListUbigeo)
                .HasForeignKey(v => v.DistritoId);



            modelBuilder.Entity<Venta>().ToTable("Venta");
            modelBuilder.Entity<Venta>().HasKey(a => a.VentaId);
            modelBuilder.Entity<Venta>().HasRequired(v => v.CentroAtencion)
                .WithMany(g => g.ListVenta)
                .HasForeignKey(v => v.CentroAtencionId).WillCascadeOnDelete(false); ;
            modelBuilder.Entity<Venta>().HasRequired(v => v.Evaluacion)
                .WithMany(g => g.ListaVenta)
                .HasForeignKey(v => v.EvaluacionId);
            modelBuilder.Entity<Venta>().HasRequired(v => v.LineaTelefonica)
                .WithMany(g => g.ListaVenta)
                .HasForeignKey(v => v.LineaTelefonicaId);
            modelBuilder.Entity<Venta>().HasRequired(v => v.TipoPago)
                .WithMany(g => g.ListVenta)
                .HasForeignKey(v => v.TipoPagoId);
            modelBuilder.Entity<Venta>().HasRequired(v => v.Trabajador)
                .WithMany(g => g.ListVenta)
                .HasForeignKey(v => v.TrabajadorId).WillCascadeOnDelete(false); ;





            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<LineaTelefonica.Entities.Entities.TipoPlan> TipoPlans { get; set; }

        public System.Data.Entity.DbSet<LineaTelefonica.Entities.Entities.TipoPago> TipoPagoes { get; set; }

        public System.Data.Entity.DbSet<LineaTelefonica.Entities.Entities.TipoTrabajador> TipoTrabajadors { get; set; }

        public System.Data.Entity.DbSet<LineaTelefonica.Entities.Entities.EstadoEvaluacion> EstadoEvaluacions { get; set; }

        public System.Data.Entity.DbSet<LineaTelefonica.Entities.Entities.TipoEvaluacion> TipoEvaluacions { get; set; }

        public System.Data.Entity.DbSet<LineaTelefonica.Entities.Entities.TipoLinea> TipoLineas { get; set; }

    }
}
