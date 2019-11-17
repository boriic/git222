using MonoProject.Models;
using MonoProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;   

namespace MonoProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapper.Mapper.Initialize(x =>
            {
                x.CreateMap<VehicleMakeVM, VehicleMakeEntity>().ReverseMap();
                x.CreateMap<VehicleModelVM, VehicleModelEntity>().ForMember(
                    dest => dest.VehicleMakeEntityId, opt => opt.MapFrom
                    (src => src.VehicleMakeVMId)).ForMember(
                    dest => dest.VehicleMakeEntity, opt => opt.MapFrom(
                        src=> src.VehicleMakeVM))
                .ReverseMap().ForMember(
                    dest => dest.VehicleMakeVMId, opt => opt.MapFrom
                    (src => src.VehicleMakeEntityId)).ForMember(
                    dest => dest.VehicleMakeVM, opt => opt.MapFrom(
                        src=>src.VehicleMakeEntity));
            });
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }       
    }
}
