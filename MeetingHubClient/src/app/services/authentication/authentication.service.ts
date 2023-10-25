import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MarshService } from '../marsh.service';
import { FormResponseModel } from 'src/app/interfaces/general-response-model';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {

  constructor(private http: HttpClient, private marsh: MarshService) {

    
  }

  registerMerchant(data: FormData) {
    return this.http.post<string>(this.marsh.baseURL + 'register-user', data);
  }





}
