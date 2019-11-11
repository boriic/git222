using AutoMapper;
using AutoMapper.Configuration;
using MonoProject.Models;
using MonoProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoProject.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public void AutoMapper()
        {
                CreateMap<VehicleMakeVM, VehicleMakeEntity>().ReverseMap();
                CreateMap<VehicleModelVM, VehicleModelEntity>().ReverseMap();
        }
    }
}