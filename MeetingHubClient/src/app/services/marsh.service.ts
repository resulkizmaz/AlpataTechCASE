import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { AuthenticationService } from './authentication/authentication.service';

@Injectable({
  providedIn: 'root'
})
export class MarshService {

  //public readonly BaseURL : string = "https://localhost:65441/";
  constructor(private http: HttpClient, private auth : AuthenticationService) {
    
    
   }

  
}
