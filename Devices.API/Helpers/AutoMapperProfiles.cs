using System.Linq;
using AutoMapper;
using Devices.API.Dtos;
using Devices.API.Models;

namespace Devices.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Device, DeviceForListDto>()
              .ForMember(dest=> dest.Status , opt => 
                opt.MapFrom(src => src.Usages.OrderByDescending(u => u.DateTime).FirstOrDefault().Status));

            CreateMap<RelatedDevice, DeviceForListDto>()
              .ForMember(dest=> dest.Id , opt => 
                opt.MapFrom(src => src.RDevice.Id))
              .ForMember(dest=> dest.Name , opt => 
                opt.MapFrom(src => src.RDevice.Name))
              .ForMember(dest=> dest.PhotoUrl , opt => 
                opt.MapFrom(src => src.RDevice.PhotoUrl))
              .ForMember(dest=> dest.Status , opt => 
                opt.MapFrom(src => src.RDevice.Usages.OrderByDescending(u => u.DateTime).FirstOrDefault().Status));

            CreateMap<Device, DeviceForDetailedDto>()
              .ForMember(dest=> dest.Status , opt => 
                opt.MapFrom(src => src.Usages.OrderByDescending(u => u.DateTime).FirstOrDefault().Status))
              .ForMember(dest=> dest.Temperature , opt => 
                opt.MapFrom(src => src.Usages.OrderByDescending(u => u.DateTime).FirstOrDefault().Temperature))
              .ForMember(dest=> dest.UsageList , opt => 
                opt.MapFrom(src => src.Usages.OrderByDescending(u => u.DateTime).Where(u => u.DeviceId == src.Id).Take(3).Select(u => u.Temperature).ToList()))
              .ForMember(dest=> dest.RelatedDevices , opt => 
                opt.MapFrom(src => src.Devices));
        }
    }
}