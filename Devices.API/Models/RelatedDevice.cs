namespace Devices.API.Models
{
    public class RelatedDevice
    {
        public int DeviceId { get; set; }
        
        public virtual Device Device { get; set; }

        public int RDeviceId { get; set; }

        public virtual Device RDevice { get; set; }
    }
}