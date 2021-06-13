import { Component } from '@angular/core';
import { AuthService } from './shared/auth.service';
import { UserService } from './shared/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  constructor (private auth : AuthService, private uservice : UserService){
    auth.user$.subscribe(user =>{
      if(user){
        uservice.save(user);
      }
    })
  }
}
