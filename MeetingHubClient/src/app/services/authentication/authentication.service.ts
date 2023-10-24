import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { UserInfo } from 'src/app/models/User.model';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  public userSubject: BehaviorSubject<UserInfo>; // BehaviorSubject : Anlık olarak tüm subs. etkileşimde olduğu için.
  
  constructor(private http: HttpClient) {
    this.userSubject = new BehaviorSubject<UserInfo>({});
  }

  /*
  Fonksiyonu doğrudan property olarak kullanabilmek için.
  public readonly getUserInfo():UserInfo{
    get{
      return this.userSubject.value;
    }    
  }
  */
  public get userInfoValue(): UserInfo {
    return this.userSubject.value;
  }

  SignIn(email:string,password:string):string{
    const url : string = `${environment.apiUrl}/auth/login`
    return url;
  }


}

