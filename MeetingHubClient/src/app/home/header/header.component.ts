import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit,OnDestroy {
  ngOnSubscribe = new Subject();
  ngOnInit(): void {
  }


  ngOnDestroy(): void {
    this.ngOnSubscribe.next(true);
    this.ngOnSubscribe.complete();
  }

  logOut(){
    console.log("logged out!");
    //authorization işleminden sonra routerLink ile log-in componentine gidecek
  }

}
