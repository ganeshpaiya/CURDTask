using Application.DTO;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Staff, CreateStaffDto>().ReverseMap();
            CreateMap<Staff, UpdateStaffDto>().ReverseMap();
            CreateMap<Staff, StaffDto>().ReverseMap();


        }
    }
}
