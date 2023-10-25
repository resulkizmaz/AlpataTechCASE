import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MarshService } from '../marsh.service';
import { UserLoginRequest, UserLoginResult, UserRegisterResult } from 'src/app/models/User.model';
import { query } from '@angular/animations';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {

  constructor(private http: HttpClient, private marsh: MarshService) {

    
  }

  registerMerchant(data: FormData) {
    return this.http.post<UserRegisterResult>(this.marsh.baseURL + 'user/register-user',data);
  }

  requestLogIn(data: UserLoginRequest){
    return this.http.get<UserLoginResult>(this.marsh.baseURL +`user/log-in?email=${data.email}&password=${data.password}`);
  }




}
