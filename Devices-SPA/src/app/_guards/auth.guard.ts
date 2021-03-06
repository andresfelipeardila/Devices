import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private route: Router,
  ) {}

  canActivate(next: ActivatedRouteSnapshot): boolean {  
    return true;
  }
}
