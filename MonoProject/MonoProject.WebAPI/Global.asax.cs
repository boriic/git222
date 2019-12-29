using Mono.Project.WebAPI.Models;
using Mono.Project.WebAPI.Module;
using MonoProject.DAL.Context;
using MonoProject.DAL.Entities;
using MonoProject.Model;
using MonoProject.Model.Common;
using MonoProject.WebAPI;
using MonoProject.WebAPI.Models;
using Newtonsoft.Json;
using Ninject;
using Ninject.Web.Common.WebHost;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Mono.Project.WebAPI
{
    public class WebApiApplication : NinjectHttpApplication
    {
        public static IKernel LocalKernel { get; set; }
        protected override IKernel CreateKernel()
        {
            // Pass in your Module setup
            var kernel = new StandardKernel(new MyModule());
            LocalKernel = kernel;

            return kernel;
        }
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AutoMapper.Mapper.Initialize(x =>
            {
                x.CreateMap<VehicleMakeVM, VehicleMake>().ForMember(
                    dest => dest.VehicleModels, opt => opt.MapFrom
                    (src => src.VehicleModelVMs)).ReverseMap().ForMember(
                    dest => dest.VehicleModelVMs, opt => opt.MapFrom(
                        src => src.VehicleModels));
                x.CreateMap<VehicleModelVM, VehicleModel>().ForMember(
                    dest => dest.VehicleMakeId, opt => opt.MapFrom
                    (src => src.VehicleMakeVMId)).ForMember(
                    dest => dest.VehicleMake, opt => opt.MapFrom(
                        src => src.VehicleMakeVM))
                .ReverseMap().ForMember(
                    dest => dest.VehicleMakeVMId, opt => opt.MapFrom
                    (src => src.VehicleMakeId)).ForMember(
                    dest => dest.VehicleMakeVM, opt => opt.MapFrom(
                        src => src.VehicleMake));

                x.CreateMap<IVehicleMake, VehicleMakeEntity>().ForMember(
                    dest => dest.VehicleModelEntities, opt => opt.MapFrom(
                        src => src.VehicleModels)).ReverseMap().ForMember(
                    dest => dest.VehicleModels, opt => opt.MapFrom(
                            src => src.VehicleModelEntities));
                x.CreateMap<IVehicleModel, VehicleModelEntity>().ForMember(
                    dest => dest.VehicleMakeEntityId, opt => opt.MapFrom
                    (src => src.VehicleMakeId)).ForMember(
                    dest => dest.VehicleMakeEntity, opt => opt.MapFrom(
                        src => src.VehicleMake))
                    .ReverseMap().ForMember(
                    dest => dest.VehicleMakeId, opt => opt.MapFrom(
                        src => src.VehicleMakeEntityId)).ForMember(
                    dest => dest.VehicleMake, opt => opt.MapFrom(
                        src => src.VehicleMakeEntity));

                x.CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
                x.CreateMap<IVehicleModel, VehicleModel>().ReverseMap();

                x.CreateMap<VehicleMake, VehicleMakeEntity>().ForMember(
                dest => dest.VehicleModelEntities, opt => opt.MapFrom(
                        src => src.VehicleModels)).ReverseMap().ForMember(
                    dest => dest.VehicleModels, opt => opt.MapFrom(
                        src => src.VehicleModelEntities));
                x.CreateMap<VehicleModel, VehicleModelEntity>().ForMember(
                    dest => dest.VehicleMakeEntityId, opt => opt.MapFrom
                    (src => src.VehicleMakeId)).ForMember(
                    dest => dest.VehicleMakeEntity, opt => opt.MapFrom(
                        src => src.VehicleMake))
                    .ReverseMap().ForMember(
                    dest => dest.VehicleMakeId, opt => opt.MapFrom(
                        src => src.VehicleMakeEntityId)).ForMember(
                    dest => dest.VehicleMake, opt => opt.MapFrom(
                        src => src.VehicleMakeEntity));
                x.CreateMap<IVehicleMake, VehicleMakeVM>().ForMember(
                    dest => dest.VehicleModelVMs, opt => opt.MapFrom(
                        src => src.VehicleModels)).ReverseMap().ForMember(
                    dest => dest.VehicleModels, opt => opt.MapFrom(
                               src => src.VehicleModelVMs));
                x.CreateMap<IVehicleModel, VehicleModelVM>().ForMember(
                    dest => dest.VehicleMakeVMId, opt => opt.MapFrom
                    (src => src.VehicleMakeId)).ForMember(
                    dest => dest.VehicleMakeVM, opt => opt.MapFrom(
                        src => src.VehicleMake))
                    .ReverseMap().ForMember(
                    dest => dest.VehicleMakeId, opt => opt.MapFrom(
                        src => src.VehicleMakeVMId)).ForMember(
                    dest => dest.VehicleMake, opt => opt.MapFrom(
                        src => src.VehicleMakeVM));
                x.CreateMap<ShortVehicleMakeVM, VehicleMake>().ReverseMap();
                x.CreateMap<ShortVehicleMakeVM, IVehicleMake>().ReverseMap();
            });
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            Database.SetInitializer<Context>(null);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }
    }
}

