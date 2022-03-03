import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Device } from '../_models/device';

@Injectable({
  providedIn: 'root'
})
export class DeviceService {

  username = environment.apiUsername;
  password = environment.apiPassword;
  baseUrl = environment.apiUrl;
 
  headers = new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'Basic ' + btoa(this.username + ':' + this.password)
  });

  private deviceName = new BehaviorSubject('');
  currentName = this.deviceName.asObservable();

  constructor(private http: HttpClient) { }

  getDevices(name: string) {
    const httpOptions = {
      headers: this.headers
    };
    
    return this.http.get<Device[]>(this.baseUrl + 'devices/'+ name, httpOptions);
  }

  getDeviceDetails(id: number) {
    const httpOptions = {
      headers: this.headers
    };
    
    return this.http.get<Device>(this.baseUrl + 'device/'+id+'/details', httpOptions);
  }

  changeDeviceName(deviceCurrentName: string) {
    this.deviceName.next(deviceCurrentName)
  }

}
