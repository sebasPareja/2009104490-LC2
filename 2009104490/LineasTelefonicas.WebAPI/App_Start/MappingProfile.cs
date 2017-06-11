using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LineaTelefonica.Entities.Entities;
using LineaTelefonica.Entities.EntitiesDTO;

namespace LineasTelefonicas.WebAPI.App_Start
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            //CreateMap<Project, ProjectCreate>();
        }

        public MappingProfile()
        {
            CreateMap<AdministradorEquipo, AdministradorEquipoDTO>();
            CreateMap<AdministradorEquipoDTO, AdministradorEquipo>();

            CreateMap<AdministradorLinea, AdministradorLineaDTO>();
            CreateMap<AdministradorLineaDTO, AdministradorLinea>();

            CreateMap<CentroAtencion, ClienteDTO>();
            CreateMap<ClienteDTO, CentroAtencion>();

            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();

            CreateMap<Contrato, ContratoDTO>();
            CreateMap<ContratoDTO, Contrato>();

            CreateMap<Departamento, DepartamentoDTO>();
            CreateMap<DepartamentoDTO, Departamento>();

            CreateMap<Direccion, DireccionDTO>();
            CreateMap<DireccionDTO, Direccion>();

            CreateMap<Distrito, DistritoDTO>();
            CreateMap<DistritoDTO, Distrito>();

            CreateMap<EquipoCelularDTO, EquipoCelular>();
            CreateMap<EquipoCelular, EquipoCelularDTO>();

            ///

            CreateMap<EstadoEvaluacionDTO, EstadoEvaluacion>();
            CreateMap<EstadoEvaluacion, EstadoEvaluacionDTO>();

            CreateMap<EvaluacionDTO, Evaluacion>();
            CreateMap<Evaluacion, EvaluacionDTO>();

            CreateMap<LineaTelefonicaDTO, LineaTelefonica.Entities.Entities.LineaTelefonica>();
            CreateMap<LineaTelefonica.Entities.Entities.LineaTelefonica, LineaTelefonicaDTO>();

            CreateMap<PlanDTO, Plan>();
            CreateMap<Plan, PlanDTO>();

            CreateMap<ProvinciaDTO, Provincia>();
            CreateMap<Provincia, ProvinciaDTO>();


            CreateMap<TipoEvaluacion, TipoEvaluacionDTO>();
            CreateMap<TipoEvaluacionDTO, TipoEvaluacion>();


            CreateMap<TipoLinea, TipoLineaDTO>();
            CreateMap<TipoLineaDTO, TipoLinea>();

            CreateMap<TipoPago, TipoPagoDTO>();
            CreateMap<TipoPagoDTO, TipoPago>();

            CreateMap<Trabajador, TrabajadorDTO>();
            CreateMap<TrabajadorDTO, Trabajador>();

            CreateMap<Ubigeo, UbigeoDTO>();
            CreateMap<UbigeoDTO, Ubigeo>();

            CreateMap<Venta, VentaDTO>();
            CreateMap<VentaDTO, Venta>();
        }

    }
}