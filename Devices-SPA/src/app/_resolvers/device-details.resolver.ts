import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { DeviceService } from '../_services/device.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Device } from '../_models/device';

@Injectable()
export class DeviceDetailsResolver implements Resolve<Device> {
    
    constructor(private deviceService: DeviceService, private router: Router) {
        console.log("constructor resolver")
    }

    resolve(route: ActivatedRouteSnapshot): Observable<Device> {
        return this.deviceService.getDeviceDetails(route.params.id).pipe(
            catchError(error => {              
                console.log("this is the error" + error)
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}