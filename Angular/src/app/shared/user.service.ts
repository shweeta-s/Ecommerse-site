import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { SocialUser } from 'angularx-social-login';
import { User } from '../model/User/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly rootUrl = 'http://localhost:22609/api'
  constructor(private http : HttpClient) { }

  

  save (socialUser : SocialUser){
    let user = new User();
    user.email = socialUser.email;
    user.name = socialUser.name;
    return this.http.post<User>(this.rootUrl+'/users',user).subscribe(
      data =>{
        console.log(console.error())
      }
    );
    }
}
