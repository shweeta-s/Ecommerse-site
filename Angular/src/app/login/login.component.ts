import { Component, OnInit } from '@angular/core';
import { SocialUser } from 'angularx-social-login';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: SocialUser | null; 
  readonly rootUrl = 'http://localhost:22609/api'

  constructor(private authservice : AuthService) 
  { 
    
  }

  ngOnInit(): void {
   
  }

  login(){
    this.authservice.signInWithGoogle();
  }
  

}
