using System;

namespace Devices.API.Models
{
    public class Usage
    {
        public int Id { get; set; }

        public virtual Device Device { get; set; }

        public int DeviceId { get; set; }
        
        public DateTime DateTime { get; set; }

        public int Temperature { get; set; }

        public string Status { get; set; }
    }
}