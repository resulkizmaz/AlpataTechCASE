import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { AuthenticationService } from './authentication/authentication.service';

@Injectable({
  providedIn: 'root'
})
export class MarshService {

  public readonly baseURL : string = "https://localhost44344/api/";
  constructor(private http: HttpClient, private auth : AuthenticationService) {
    
    
   }

  
}
