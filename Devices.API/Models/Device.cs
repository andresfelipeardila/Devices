using System;
using System.Collections.Generic;

namespace Devices.API.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public virtual ICollection<RelatedDevice> Devices { get; set; }
        public virtual ICollection<RelatedDevice> RDevices { get; set; }
        public virtual ICollection<Usage> Usages { get; set; }
    }
}