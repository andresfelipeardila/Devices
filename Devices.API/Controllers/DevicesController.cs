using System.Linq;
using System.Threading.Tasks;
using Devices.API.Data;
using Devices.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using AutoMapper;
using System.Collections.Generic;
using Devices.API.Dtos;
using Microsoft.AspNetCore.Cors;

namespace Devices.API.Controllers
{
    [ApiController]
    public class DevicesController  : ControllerBase
    {
        private readonly IDeviceRepository _repo;
        private readonly IMapper _mapper; 

        public DevicesController(IDeviceRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]/{deviceName?}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> GetDevices(string deviceName=null) 
        {
            var devicesFromRepo = new List<Device>();

            if(deviceName == null) {
                devicesFromRepo = await _repo.GetAllDevices();
            }
            else {
                devicesFromRepo = await _repo.GetDevicesByName(deviceName);
            }
            
            var devices = _mapper.Map<IEnumerable<DeviceForListDto>>(devicesFromRepo);
        
            return Ok(devices);
        }

        [HttpGet]
        [Route("api/device/{deviceid}/details")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> GetDeviceDetails(int deviceId) 
        {
            var deviceFromRepo = new Device();

            deviceFromRepo =  await _repo.GetDevicesById(deviceId);   
        
            var device = _mapper.Map<DeviceForDetailedDto>(deviceFromRepo);
        
            return Ok(device);
        }

    }
}