import { Component, OnInit } from '@angular/core';
import { DeviceService } from 'src/app/_services/device.service';
import { ActivatedRoute } from '@angular/router';
import { Device } from 'src/app/_models/device';
import { DeviceDetails } from 'src/app/_models/deviceDetails';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';

@Component({
  selector: 'app-device-detail',
  templateUrl: './device-detail.component.html',
  styleUrls: ['./device-detail.component.css']
})
export class DeviceDetailComponent implements OnInit {


  deviceDetails: DeviceDetails;

  constructor(private deviceService: DeviceService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.deviceDetails = data.user;
    });
  }

}
