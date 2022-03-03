import { Component, OnInit } from '@angular/core';
import { DeviceService } from 'src/app/_services/device.service';
import { ActivatedRoute } from '@angular/router';
import { Device } from 'src/app/_models/device';
import { MatIconModule } from '@angular/material/icon';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrls: ['./device-list.component.css']
})
export class DeviceListComponent implements OnInit {

  devices: Device[];
  currentDeviceName: string = '';

  constructor(private deviceService: DeviceService, private route: ActivatedRoute) { }

  ngOnInit() {
    /* this.route.data.subscribe(data => {
       this.devices = data.devices;
       console.log(this.devices);
    });  */
    
   // this.devices = this.deviceService.getDevices('').pipe(take(2)).subscribe();

 
    this.deviceService.currentName.subscribe(name => {
      this.currentDeviceName = name;
      this.loadDevices();
    })

    console.log("device list");
    this.loadDevices();
  }

  loadDevices() {
    console.log("load devices");
  
    this.deviceService.getDevices(this.currentDeviceName).subscribe((res: Device[]) => {
      this.devices = res;
      console.log(this.devices)
    }, error => {
      console.log(error);
    });
  }
}
