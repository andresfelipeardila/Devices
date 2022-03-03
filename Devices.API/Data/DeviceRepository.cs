using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Devices.API.Models;


namespace Devices.API.Data
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DataContext _context;

        public DeviceRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }


        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Device>> GetDevicesByName(string name)
        {
            var devices = await _context.Devices.Include(p => p.Usages).Where(d => d.Name.Contains(name)).ToListAsync();
            return devices;
        }

        public async Task<List<Device>> GetAllDevices() 
        {    
            var devices = await _context.Devices.ToListAsync();
            return devices;
        }

        public async Task<Device> GetDevicesById(int id)
        {
            var device = await _context.Devices.Include(p => p.Usages).Where(d => d.Id == id).FirstOrDefaultAsync();
            return device;
        }
    }
}