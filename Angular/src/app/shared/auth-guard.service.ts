import { Injectable } from '@angular/core';
import { CanActivate, RouteReuseStrategy, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators'


@Injectable()
export class AuthGuardService implements CanActivate {

  constructor(private authService: AuthService, private router : Router) { }

  canActivate() {

    if (this.authService.isAuthenticated()) {
      return true;
  }

  this.router.navigate(['/login']);
  return false;
  }  
  
}
  

