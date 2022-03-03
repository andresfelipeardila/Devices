using Devices.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Devices.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Device> Devices { get; set; }
        public DbSet<Usage> Usages { get; set; }
        public DbSet<RelatedDevice> RelatedDevices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Usage>()
                .HasOne(n => n.Device)
                .WithMany(u => u.Usages)
                .HasForeignKey(n => n.DeviceId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<RelatedDevice>(relatedDevice => 
            {
                relatedDevice.HasKey(m => new { m.DeviceId, m.RDeviceId });

                relatedDevice.HasOne(n => n.Device)
                .WithMany(r => r.Devices)
                .HasForeignKey(n => n.DeviceId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);;

                relatedDevice.HasOne(n => n.RDevice)
                .WithMany(d => d.RDevices)
                .HasForeignKey(n => n.RDeviceId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            });

            
        }
    }
}