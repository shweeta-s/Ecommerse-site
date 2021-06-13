import { Injectable } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { SocialAuthService  } from 'angularx-social-login';
import { SocialUser } from 'angularx-social-login';
import { GoogleLoginProvider } from 'angularx-social-login';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  user$ : Observable<SocialUser>;


  constructor(private authService: SocialAuthService) { 
    this.user$= authService.authState;
  }

  signInWithGoogle() {
    this.authService.signIn(GoogleLoginProvider.PROVIDER_ID).then((x: any) => console.log(x));
    this.user$.subscribe({
      next : data=>{
        localStorage.setItem('access_token',data.authToken);
      },
      error : error=>{
        console.log(error)
      }
    })
    
  }

  signOut() {
    this.authService.signOut();
    localStorage.removeItem('access_token')
  }  

  isAuthenticated() {
    let token = localStorage.getItem('access_token');

    if (token) {
        return true;
    }

    return false;
  }
}
