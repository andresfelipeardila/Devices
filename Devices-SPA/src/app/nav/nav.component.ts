import { Component, OnInit } from '@angular/core';
import { DeviceService } from '../_services/device.service';
import { ActivatedRoute } from '@angular/router';
import { VirtualTimeScheduler } from 'rxjs';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  deviceSearchName: string ='';

  constructor(private deviceService: DeviceService, private route: ActivatedRoute) { }

  ngOnInit() {

  }

  newCurrentDevice() {
    this.deviceService.changeDeviceName(this.deviceSearchName);
  }

  clearSearch() {
    this.deviceSearchName = '';
    this.deviceService.changeDeviceName(this.deviceSearchName);
  }

}
