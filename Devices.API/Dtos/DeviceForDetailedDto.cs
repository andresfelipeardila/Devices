using System.Collections.Generic;

namespace Devices.API.Dtos
{
    public class DeviceForDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Temperature { get; set; }
        public string PhotoUrl { get; set; }
        public List<int> UsageList { get; set;}
        public ICollection<DeviceForListDto> RelatedDevices { get; set; }
    }
}