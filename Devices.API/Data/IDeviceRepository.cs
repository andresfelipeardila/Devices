using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devices.API.Models;

namespace Devices.API.Data
{
    public interface IDeviceRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<List<Device>> GetDevicesByName(string name);
         Task<List<Device>> GetAllDevices();
         Task<Device> GetDevicesById(int id);
    }
}