import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { AuthenticationService } from 'src/app/services/authentication/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit,OnDestroy {
  isLogged :boolean;
  constructor(private auth:AuthenticationService){
    this.isLogged = auth.isLogged;
  }
  ngOnSubscribe = new Subject();
  ngOnInit(): void {
  }


  ngOnDestroy(): void {
    this.ngOnSubscribe.next(true);
    this.ngOnSubscribe.complete();
  }

  logOut(){
    this.isLogged = false;
    //authorization işleminden sonra routerLink ile log-in componentine gidecek
  }

}
