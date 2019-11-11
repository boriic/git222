using AutoMapper;
using MonoProject.Models;
using MonoProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoProject.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VehicleMakeVM, VehicleMakeEntity>().ReverseMap();
            CreateMap<VehicleModelVM, VehicleModelEntity>().ReverseMap();
        }

    }
}