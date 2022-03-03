using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devices.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Devices.API.Data
{
    public class Seed
    {
        public static async Task SeedDevices(DataContext dc)
        {
            var format = "dd/MM/yyyy hh:mm:ss"; // your datetime format
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };

            var devicesData = System.IO.File.ReadAllText("Data/DevicesSeedData.json");
            var devices = JsonConvert.DeserializeObject<List<Device>>(devicesData, dateTimeConverter);

            if(!dc.Devices.Any())
            {
                foreach (var device in devices)
                {
                    await dc.Devices.AddAsync(device);
                }
                await SeedRelatedDevices(dc);

                await dc.SaveChangesAsync();
            }
            
        }

        public static async Task SeedRelatedDevices(DataContext dc) {
            
            var relatedDevice1 = new RelatedDevice();
            relatedDevice1.DeviceId = 1;
            relatedDevice1.RDeviceId = 2;
            await dc.RelatedDevices.AddAsync(relatedDevice1);


            var relatedDevice2 = new RelatedDevice();
            relatedDevice2.DeviceId = 1;
            relatedDevice2.RDeviceId = 3;
            await dc.RelatedDevices.AddAsync(relatedDevice2);

            var relatedDevice3 = new RelatedDevice();
            relatedDevice3.DeviceId = 2;
            relatedDevice3.RDeviceId = 1;
            await dc.RelatedDevices.AddAsync(relatedDevice3);

        }
    }
}